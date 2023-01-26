using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccessLayer.Abstract;
using Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByMail(string mail)
        {
            var result = _userDal.Get(u => u.Email == mail);
            if (result == null)
            {
                return new ErrorDataResult<User>();
            }
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetOperationClaims(user));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }


        public IDataResult<User> ChangeToPassword(UserForLoginDto userForLoginDto, string newPasssword)
        {
            byte[] passwordSalt, passwordHash;

            var user = _userDal.Get(u=>u.Email == userForLoginDto.Email);
            HashingHelper.CreatePasshordHash(newPasssword, out passwordSalt, out passwordHash);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            _userDal.Update(user);
            return new SuccessDataResult<User>(user, "Şifre Değiştirildi");

        }
    }
}
