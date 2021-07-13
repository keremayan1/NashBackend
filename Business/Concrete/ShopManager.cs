using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ShopManager : IShopService
    {
        IShopDal _shopDal;
        IPersonService _personService;
        IPersonShopService _personShopService;

        public ShopManager(IShopDal shopDal, IPersonService personService, IPersonShopService personShopService)
        {
            _shopDal = shopDal;
            _personService = personService;
            _personShopService = personShopService;
        }

        public async Task<IResult> AddAsync(ShopDetailDto shopDetailDto)
        {
            var person = Person(shopDetailDto);
            var shop = Shop(shopDetailDto);
            await _personService.AddAsync(person);
            await _shopDal.AddAsync(shop);
            await _personShopService.AddAsync(new PersonShop { PersonId = person.Id, ShopId = shop.Id });
            return new SuccessResult();
        }
        public async Task<IResult> DeleteAsync(ShopDetailDto shopDetailDto)
        {
            var person = Person(shopDetailDto);
            var shop = Shop(shopDetailDto);
            await _personService.DeleteAsync(person);
            await _shopDal.DeleteAsync(shop);
            await _personShopService.DeleteAsync(new PersonShop { PersonId = person.Id, ShopId = shop.Id });
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Shop>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Shop>>(await _shopDal.GetAllAsync());
        }

        public async Task<IDataResult<List<Shop>>> GetByShopIdAsync(int id)
        {
            return new SuccessDataResult<List<Shop>>(await _shopDal.GetAllAsync(s => s.Id == id));
        }

        public IDataResult<List<ShopDetailDto>> GetShops(Shop shop)
        {
            return new SuccessDataResult<List<ShopDetailDto>>(_shopDal.GetShopDetails().Result);
        }

        public async Task<IResult> UpdateAsync(ShopDetailDto shopDetailDto)
        {
            var person = Person(shopDetailDto);
            var shop = Shop(shopDetailDto);
            await _personService.UpdateAsync(person);
            await _shopDal.UpdateAsync(shop);
            await _personShopService.UpdateAsync(new PersonShop { PersonId = person.Id, ShopId = shop.Id });
            return new SuccessResult();
        }
        private Person Person(ShopDetailDto shopDetailDto)
        {
            return new Person
            {
                NationalId = shopDetailDto.NationalId,
                Name = shopDetailDto.Name,
                LastName = shopDetailDto.LastName,
                DateOfBirth = shopDetailDto.DateOfBirth,
            };
        }
        private static Shop Shop(ShopDetailDto shopDetailDto)
        {
            return new Shop
            {
                TaxNumber = shopDetailDto.TaxNumber
            };
        }
    }
}
