
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<User>>> GetAll();
        Task<IResult> Add(User entity);
        Task<IResult> Update(User entity);
        Task<IResult> Delete(User entity);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        Task<IResult> EditPassword(UserForUpdateDto userForUpdateDto, string newPassword, string newPasswordVerify);
        Task<IResult> EditProfil(User user);

    }
}
