using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete.Dto;
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

        public async Task<IResult> Add(User entity)
        {
            await _userDal.AddAsync(entity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> Delete(User entity)
        {
            await _userDal.DeleteAsync(entity);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IResult> EditPassword(UserForUpdateDto userForUpdateDto, string newPassword, string newPasswordVerify)
        {
            byte[] passwordHash, passwordSalt;
            var result = BusinessRules.Run(CheckPasswordSame(newPassword, newPasswordVerify), CheckPasswordOldWrong(userForUpdateDto));
            if (result != null)
            {
                return result;
            }
            HashingHelper.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);
            var updatePassword = new User
            {
                Id = userForUpdateDto.User.Id,
                FirstName = userForUpdateDto.User.FirstName,
                LastName = userForUpdateDto.User.LastName,
                Email = userForUpdateDto.User.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = userForUpdateDto.User.Status
            };
            await _userDal.UpdateAsync(updatePassword);
            return new SuccessResult();
        }

        public async Task<IResult> EditProfil(User user)
        {
            var updatedUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Status = user.Status,
            };
            await _userDal.UpdateAsync(user);
            return new SuccessResult();

        }

        public async Task<IDataResult<List<User>>> GetAll()
        {
            return new SuccessDataResult<List<User>>(await _userDal.GetAllAsync());
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public async Task<IResult> Update(User entity)
        {
            await _userDal.UpdateAsync(entity);
            return new SuccessResult(Messages.ProductUpdated);
        }
        //Business Rules
        private IResult CheckPasswordOldWrong(UserForUpdateDto userForUpdateDto)
        {
            var userToCheck = this.GetByMail(userForUpdateDto.User.Email);
            if (userToCheck == null)
            {
                return new ErrorResult("Kullanici Bulunamadi!");
            }
            if (!HashingHelper.VerifyPasswordHash(userForUpdateDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorResult("Eski Sifre girildi");
            }
            return new SuccessResult();
        }
        private IResult CheckPasswordSame(string password, string passwordVerify)
        {
            var result = password == passwordVerify;
            if (!result)
            {
                return new ErrorResult("Sifreler Ayni Degil");
            }
            return new SuccessResult();
        }

    }
}
