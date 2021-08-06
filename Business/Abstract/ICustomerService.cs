
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public  interface ICustomerService
    {
        Task<IDataResult<List<Customer>>> GetAllAsync();
        Task<IDataResult<List<Customer>>> GetByIdAsync(int id);
   
        Task<IResult> AddAsync(Customer customer);
        Task<IResult> UpdateAsync(Customer customer);
        Task<IResult> DeleteAsync(Customer customer);

    }
}
