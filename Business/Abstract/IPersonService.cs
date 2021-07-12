
using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public  interface IPersonService
    {
        Task<IDataResult<List<Person>>> GetAllAsync();
        Task<IResult> AddAsync(Person entity);
        Task<IResult> UpdateAsync(Person entity);
        Task<IResult> DeleteAsync(Person entity);
        Task<IDataResult<List<Person>>> GetByIdAsync(int id);
        
    }
}
