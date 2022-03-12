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
    }
}
