
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IPersonCustomerService
    {
        Task<IDataResult<List<PersonCustomer>>> GetAllAsync();
        Task<IResult> AddAsync(PersonCustomer entity);
        Task<IResult> UpdateAsync(PersonCustomer entity);
        Task<IResult> DeleteAsync(PersonCustomer entity);
        Task<IDataResult<List<PersonCustomer>>> GetByIdAsync(int id);
    }
}
