using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        IUserOperationClaimService _userOperationClaimService;

        public AuthManager(IUserService userService,ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var token = _tokenHelper.CreateAccessToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(token,"Token Oluşturuldu.");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            BusinessRules.Run(UserExists(userForLoginDto.Email));
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.Data.PasswordSalt,userToCheck.Data.PasswordHash))
            {
                return new ErrorDataResult<User>("Şifre Hatalı");
            }
            return new SuccessDataResult<User>(userToCheck.Data,"Giriş Başarılı");

        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordSalt, passwordHash;
            BusinessRules.Run(UserExists(userForRegisterDto.Email));
            HashingHelper.CreatePasshordHash(userForRegisterDto.Password,out passwordSalt,out passwordHash);
            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                IsStatus = true
            };
            _userService.Add(user);
            var userOperationClaim = new UserOperationClaim
            {
                UserId = user.Id,
                OperationClaimId = 2
            };
            _userOperationClaimService.Add(userOperationClaim);
            return new SuccessDataResult<User>("Kayıt Başarılı");

        }

        public IResult UserExists(string mail)
        {      
            if (_userService.GetByMail(mail) == null)
            {
                return new ErrorResult("Kullanıcı kayıtlı değil");
            }
            return new SuccessResult("Kullanıcı mevcut");
        }
    }
}
