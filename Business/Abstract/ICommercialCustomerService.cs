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
   public interface ICommercialCustomerService
    {

        Task<IDataResult<List<CommercialCustomer>>> GetAll();
        Task<IResult> AddAsync(CommercialCustomerDetailDto commercialCustomerDetailDto);
       IDataResult<List<CommercialCustomerDetailDto>>GetCommercialCustomers();
    }
}
