using PracticeAPI.Adapter.Contracts;
using PracticeAPI.BusinessEntities.User;
using PracticeAPI.Facade.Contracts;
using PracticeAPI.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticeAPI.Adapter.Impl
{
    /// <inheritdoc cref="IUserAdapter"/>
    public class UserAdapter : IUserAdapter
    {
        private readonly IUserFacade _userFacade;

        public UserAdapter(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        /// <inheritdoc/>
        public async Task SaveName(string firstName, string lastName)
        {
            UserBE userBE =
                new UserBE.Builder(firstName, lastName)
                .Build();

            await _userFacade.SaveName(userBE);
        }

        public async Task<UserBE> GetUser(int userID)
        {
            UserBE userBE = await _userFacade.GetUser(userID);
            if (userBE == null)
            {
                throw new WebResponseException(HttpStatusCode.NotFound, "User could not be found for ID provided");
            }
            return userBE;
        }

        public async Task<UserBE> UpdateUser(UserBE user)
        {
            UserBE dbUser = await _userFacade.GetUser(user.UserID);
            if (dbUser == null)
            {
                throw new WebResponseException(HttpStatusCode.NotFound, "User could not be found for ID provided");
            }

            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.FullName = user.FullName;

            UserBE updatedUser = await _userFacade.UpdateUser(dbUser);

            return updatedUser;
        }
    }
}
