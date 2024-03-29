﻿using PracticeAPI.BusinessEntities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAPI.Facade.Contracts
{
    public interface IUserFacade
    {
        Task SaveName(UserBE userBE);
        Task<UserBE> GetUser(int userID);
        Task<UserBE> UpdateUser(UserBE userBE);
    }
}
