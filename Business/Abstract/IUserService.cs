﻿using Business.Generics;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService:IGenericBaseService<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);

    }
}
