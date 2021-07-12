using Core.DataAccess;
using Entities;
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
 public   interface ICustomerDal:IEntityRepository<Customer>,IAsyncEntityRepository<Customer>
    {
        List<CustomerDetailDto> GetCustomers(Expression<Func<CustomerDetailDto, bool>> filter = null);

    }
}
