using Business.Abstract;
using Business.Adapters.PersonVerificationKps;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        IPersonDal _personDal;
        

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
            
        }

        public async Task<IResult> AddAsync(Person person)
        {
            var result = BusinessRules.Run(PersonInformationToUpper(person));
            if (result!=null)
            {
                return result;
            }
            await _personDal.AddAsync(person);
            return new SuccessResult("Kayit Islemi Basarili");
            
        }

        public async Task<IResult> DeleteAsync(Person entity)
        {
            await _personDal.DeleteAsync(entity);
            return new SuccessResult("Kayit Silindi");
        }

        public async Task<IDataResult<List<Person>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Person>>(await _personDal.GetAllAsync());
        }

        public async Task<IResult> UpdateAsync(Person person)
        {
            var result = BusinessRules.Run(PersonInformationToUpper(person));
            if (result != null)
            {
                return result;
            }

            await _personDal.UpdateAsync(person);
            return new SuccessResult("Kayit Guncellendi");

        }
        [SecuredOperation("admin")]
        public async Task<IDataResult<List<Person>>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<List<Person>>(await _personDal.GetAllAsync(p => p.Id == id));
        }
        //Business Rules
       
        private IResult PersonInformationToUpper(Person person)
        {
            person.FirstName = person.FirstName.ToUpper();
            person.LastName = person.LastName.ToUpper();
            return new SuccessResult();
        }

      
    }
}
