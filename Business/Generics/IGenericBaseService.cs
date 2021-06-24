using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Generics
{
    public interface IGenericBaseService<T>
    {
        Task<IDataResult<List<T>>> GetAll();
        Task<IResult> Add(T entity);
        Task<IResult> Update(T entity);
        Task<IResult> Delete(T entity);
    }
}
