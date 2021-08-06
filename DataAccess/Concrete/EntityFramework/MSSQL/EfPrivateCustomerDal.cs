using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.MSSQL
{
   public class EfPrivateCustomerDal:EfEntityRepository<PrivateCustomer,SqlContext>,IPrivateCustomerDal
    {
        SqlContext context = new SqlContext();
        public async Task<List<PrivateCustomerDetailDto>>GetPrivateCustomerDetailDto(Expression<Func<PrivateCustomerDetailDto, bool>> filter = null)
        {
            var result = from customer in context.Customers
                         join privateCustomer in context.PrivateCustomers
                         on customer.CustomerId equals privateCustomer.Id
                         where customer.CustomerId==privateCustomer.Id
                         select new PrivateCustomerDetailDto
                         {
                             NationalId = privateCustomer.NationalId,
                             FirstName = privateCustomer.FirstName,
                             LastName = privateCustomer.LastName,
                             DateOfBirth = privateCustomer.DateOfBirth,
                             MusteriNo = customer.MusteriNo
                         };
            return filter == null ?
               await result.ToListAsync() :
             await   result.Where(filter).ToListAsync();
                
        }
    }
}
