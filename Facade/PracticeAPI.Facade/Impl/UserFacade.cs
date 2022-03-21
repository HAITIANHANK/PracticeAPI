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
            UserEntity userEntity = new UserEntity()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName
            };
            await _dataSvc.UserRepo.SaveName(userEntity);
        }

        public async Task<UserBE> GetUser(int userID)
        {
            UserEntity userEntity = await _dataSvc.UserRepo.GetUser(userID);

            UserBE userBE = userEntity == null ? null : new UserBE()
            {
                UserID = userEntity.UserID,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                FullName = userEntity.FullName
            };

            return userBE;
        }
    }
}
