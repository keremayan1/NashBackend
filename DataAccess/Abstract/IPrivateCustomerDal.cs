using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface IPrivateCustomerDal:IEntityRepository<PrivateCustomer>,IAsyncEntityRepository<PrivateCustomer>
    {
        Task<List<PrivateCustomerDetailDto>> GetPrivateCustomerDetailDto(Expression<Func<PrivateCustomerDetailDto, bool>> filter = null);
    }
}
