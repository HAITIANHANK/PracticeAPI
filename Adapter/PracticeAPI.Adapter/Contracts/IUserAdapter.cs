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
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        Task SaveName(string firstName, string lastName);
    }
}
