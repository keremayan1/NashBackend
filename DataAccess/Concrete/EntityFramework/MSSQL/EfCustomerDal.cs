using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
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
    public class EfCustomerDal : EfEntityRepository<Customer, SqlContext>, ICustomerDal
    {
        SqlContext context = new SqlContext();
        public async Task<List<CustomerDetailDto>> GetCustomers(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            var result = from person in context.Persons
                         join personCustomer in context.PersonCustomers
                         on person.Id equals personCustomer.PersonId
                         join customers in context.Customers
                         on personCustomer.CustomerId equals customers.CustomerId
                         where person.Id==personCustomer.PersonId &&  personCustomer.CustomerId==customers.CustomerId
                         select new CustomerDetailDto
                         {
                             NationalId = person.NationalId,
                             Name = person.FirstName,
                             LastName = person.LastName,
                             DateOfBirth = person.DateOfBirth,
                           MusteriNo=customers.MusteriNo
                         };
            return filter == null ?
               await result.ToListAsync() :
                await result.Where(filter).ToListAsync();



        }


    }
}
