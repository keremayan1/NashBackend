﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.MSSQL
{
   public class EfProductDal:EfEntityRepository<Product,SqlContext>,IProductDal
    {
    }
}
