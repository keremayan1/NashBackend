
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
        Task<IResult> AddAsync(CustomerDetailDto customerDetailDto);
        Task<IResult> UpdateAsync(CustomerDetailDto customerDetailDto);
        Task<IResult> DeleteAsync(CustomerDetailDto customerDetailDto);
        Task<IDataResult<List<Customer>>> GetByIdAsync(int id);
        IDataResult<List<CustomerDetailDto>> GetCustomers();
        Task<IResult> AddAsync2(Customer customer);
        Task<IResult> UpdateAsync2(Customer customer);
        Task<IResult> DeleteAsync2(Customer customer);


    }
}
