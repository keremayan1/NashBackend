using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IProductService:IGenericBaseService<Product>
    {
        Task<IDataResult<Product>> GetByProductId(int id);




    }
}
