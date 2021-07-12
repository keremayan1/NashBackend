
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IUserOperationClaimService
    {
        Task<IDataResult<List<UserOperationClaim>>> GetAllAsync();
        Task<IResult> AddAsync(UserOperationClaim entity);
        Task<IResult> UpdateAsync(UserOperationClaim entity);
        Task<IResult> DeleteAsync(UserOperationClaim entity);
    }
}
