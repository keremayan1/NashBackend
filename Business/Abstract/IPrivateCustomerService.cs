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
   public interface IPrivateCustomerService
    {
        Task<IDataResult<List<PrivateCustomer>>> GetAll();
        Task<IResult> Add(PrivateCustomer privateCustomer);
        Task<IResult> Add2(PrivateCustomerDetailDto privateCustomer);
    }
}
