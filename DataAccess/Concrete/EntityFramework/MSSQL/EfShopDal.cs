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
    public class EfShopDal : EfEntityRepository<Shop, SqlContext>, IShopDal
    {
        SqlContext context = new SqlContext();
        public async Task<List<ShopDetailDto>> GetShopDetails(Expression<Func<ShopDetailDto, bool>> filter = null)
        {
            var result = from person in context.Persons
                         join personShop in context.PersonShops
                         on person.Id equals personShop.PersonId
                         join shop in context.Shops
                         on personShop.ShopId equals shop.Id
                         select new ShopDetailDto
                         {
                             NationalId = person.NationalId,
                             Name = person.Name,
                             LastName = person.LastName,
                             DateOfBirth = person.DateOfBirth,
                             TaxNumber = shop.TaxNumber
                         };
            return filter == null ?
               await result.ToListAsync() :
               await result.Where(filter).ToListAsync();
        }
    }
}
