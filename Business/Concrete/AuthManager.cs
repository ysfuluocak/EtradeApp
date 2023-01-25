using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
       IOperationClaimService _operationClaimService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IOperationClaimService operationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _operationClaimService = operationClaimService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var token = _tokenHelper.CreateAccessToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(token, "Token Oluşturuldu.");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordSalt, userToCheck.Data.PasswordHash))
            {
                return new ErrorDataResult<User>("Şifre Hatalı");
            }
            return new SuccessDataResult<User>(userToCheck.Data, "Giriş Başarılı");

        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasshordHash(userForRegisterDto.Password, out passwordSalt, out passwordHash);
            var roles = new HashSet<UserOperationClaim>()
            {
                new(){OperationClaimId=_operationClaimService.GetById(2).Data.Id}
            };
            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                IsStatus = true,
                Roles = roles
            };
            _userService.Add(user);
            return new SuccessDataResult<User>("Kayıt Başarılı");

        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult("Kullanıcı mevcut");
            }
            return new SuccessResult("Kayıtlı kullancı bulunamadı!");
        }
    }
}
