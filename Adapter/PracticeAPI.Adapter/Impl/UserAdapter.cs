using PracticeAPI.Adapter.Contracts;
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
        /// <inheritdoc/>
        public async Task SaveName(string firstName, string lastName)
        {

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new WebResponseException(HttpStatusCode.BadRequest, "First name must not be null, empty, or white space");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new WebResponseException(HttpStatusCode.BadRequest, "Last name must not be null, empty, or white space");
            }

            firstName = firstName.Trim();
            if (firstName.Length > 50)
            {
                throw new WebResponseException(HttpStatusCode.BadRequest, "First name cannot be more than 50 characters");
            }
            lastName = lastName.Trim();
            if (lastName.Length > 50)
            {
                throw new WebResponseException(HttpStatusCode.BadRequest, "Last name cannot be more than 50 characters");
            }

            Regex multiSpaceRegex = new Regex(@"[^\S\r\n]{2,}");
            if (multiSpaceRegex.IsMatch(firstName))
                firstName = multiSpaceRegex.Replace(firstName, " ");
            if (multiSpaceRegex.IsMatch(lastName))
                lastName = multiSpaceRegex.Replace(lastName, " ");

            // TODO: Wire up to facade once created
        }
    }
}
