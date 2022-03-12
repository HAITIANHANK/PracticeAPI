using PracticeAPI.BusinessEntities.User;
using PracticeAPI.Data;
using PracticeAPI.Data.Entities;
using PracticeAPI.Facade.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAPI.Facade.Impl
{
    public class UserFacade : IUserFacade
    {
        private readonly IPracticeAPIDataService _dataSvc;

        public UserFacade(IPracticeAPIDataService dataSvc)
        {
            _dataSvc = dataSvc;
        }

        public async Task SaveName(UserBE user)
        {
            UserEntity userEntity = user;
            await _dataSvc.UserRepo.SaveName(userEntity);
        }
    }
}
