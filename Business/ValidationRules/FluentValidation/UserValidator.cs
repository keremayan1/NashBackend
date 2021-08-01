using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("Isim en az 2 karakterli olmalidir");
            RuleFor(u => u.FirstName).MaximumLength(64).WithMessage("Isim en fazla 64 karakterli olmalidir");
            RuleFor(u => u.LastName).MaximumLength(64).WithMessage("Soyad en fazla 64 karakterli olmalidir");
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage("Soyad en az 2 karakterli olmalidir!");
            
        }
    }
}
