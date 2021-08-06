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
    public class EfCommercialCustomerDal : EfEntityRepository<CommercialCustomer, SqlContext>, ICommercialCustomerDal
    {
        SqlContext context = new SqlContext();
        public async Task<List<CommercialCustomerDetailDto>> GetCommercialCustomerDetails(Expression<Func<CommercialCustomerDetailDto, bool>> filter = null)
        {
            var result = from customer in context.Customers
                         join commercialCustomer in context.CommercialCustomers
                         on customer.CustomerId equals commercialCustomer.CustomerId
                         where customer.CustomerId == commercialCustomer.CustomerId
                         select new CommercialCustomerDetailDto
                         {
                             MusteriNo = customer.MusteriNo,
                             Title = commercialCustomer.Title,
                             TaxNumber = commercialCustomer.TaxNumber
                         };
            return filter == null ?
                await result.ToListAsync() :
            await result.Where(filter).ToListAsync();
        }
    }
}
