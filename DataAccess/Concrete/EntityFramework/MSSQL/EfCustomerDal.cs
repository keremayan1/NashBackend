using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.Concrete.Dto;
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
        public List<CustomerDetailDto> GetCustomers(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (var context = new SqlContext())
            {
                var result = from person in context.Persons
                             join personCustomer in context.PersonCustomers
                             on person.Id equals personCustomer.PersonId
                             join customers in context.Customers
                             on personCustomer.CustomerId equals customers.CustomerId
                             select new CustomerDetailDto
                             {
                                 NationalId = person.NationalId,
                                 Name = person.Name,
                                 LastName = person.LastName,
                                 DateOfBirth = person.DateOfBirth,
                                 Country = customers.Country,
                                 Phone = customers.Phone
                             };
                return filter == null ?
                    result.ToList() :
                    result.Where(filter).ToList();


            }
        }
    }
}
