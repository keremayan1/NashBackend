using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.MSSQL
{
    public class EfProductDal : EfEntityRepository<Product, SqlContext>, IProductDal
    {
        public  List<ProductDetailDto> GetProductDetails(Expression<Func<ProductDetailDto, bool>> filter = null)
        {
            using (var context = new SqlContext())
            {
                var result = from product in context.Products
                             join category in context.Categories
                             on product.CategoryId equals category.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = product.ProductId,
                                 ProductName = product.ProductName,
                                 CategoryName = category.CategoryName,
                                 UnitPrice = product.UnitPrice
                             };
                return filter == null ?
                     result.ToList() : 
                     result.Where(filter).ToList();
            }
        }
    }
}
