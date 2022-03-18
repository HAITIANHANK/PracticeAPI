using PracticeAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAPI.Data.Repos.Contracts
{
    /// <summary>
    /// A repository for working with data in the Users Table
    /// </summary>
    public interface IUserRepo
    {
        /// <summary>
        /// Saves name data to the Users table.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        Task SaveName(UserEntity user);
        /// <summary>
        /// Retrieves a user based on the ID provided.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        ///     Thrown if more than one user returned from database.
        /// </exception>
        Task<UserEntity> GetUser(int userID);
    }
}
