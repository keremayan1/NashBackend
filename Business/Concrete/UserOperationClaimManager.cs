using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public async Task<IResult> AddAsync(UserOperationClaim entity)
        {
            await _userOperationClaimDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(UserOperationClaim entity)
        {
            await _userOperationClaimDal.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<UserOperationClaim>>> GetAllAsync()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(await _userOperationClaimDal.GetAllAsync());
        }

        public async Task<IResult> UpdateAsync(UserOperationClaim entity)
        {
            await _userOperationClaimDal.UpdateAsync(entity);
            return new SuccessResult();
        }
    }
}
