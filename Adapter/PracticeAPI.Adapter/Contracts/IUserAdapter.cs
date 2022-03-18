using PracticeAPI.BusinessEntities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAPI.Adapter.Contracts
{
    /// <summary>
    /// Adapter for business validations related to a user.
    /// </summary>
    public interface IUserAdapter
    {
        /// <summary>
        /// Takes a name and saves it to the DB.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Also saves a Full Name value based on 
        ///         the received data by concatenating the
        ///         first and last names separated by a space
        ///     </para>
        /// </remarks>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        Task SaveName(string firstName, string lastName);
        Task<UserBE> GetUser(int userID);
    }
}
