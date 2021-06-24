using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.MSSQL
{
  public  class EfUserOperationClaimDal:EfEntityRepository<UserOperationClaim,SqlContext>,IUserOperationClaimDal
    {
    }
}
