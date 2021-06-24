using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess
{
    public interface IUserOperationClaimDal:IEntityRepository<UserOperationClaim>,IAsyncEntityRepository<UserOperationClaim>
    {
    }
}