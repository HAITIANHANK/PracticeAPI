using PracticeAPI.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace PracticeAPI.BusinessEntities.User
{
    public class UserBE
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        private UserBE()
        {

        }
        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                throw new WebResponseException(HttpStatusCode.BadRequest, "First name must not be null, empty, or white space");
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                throw new WebResponseException(HttpStatusCode.BadRequest, "Last name must not be null, empty, or white space");
            }

            FirstName = FirstName.Trim();
            if (FirstName.Length > 50)
            {
                throw new WebResponseException(HttpStatusCode.BadRequest, "First name cannot be more than 50 characters");
            }
            LastName = LastName.Trim();
            if (LastName.Length > 50)
            {
                throw new WebResponseException(HttpStatusCode.BadRequest, "Last name cannot be more than 50 characters");
            }

            Regex multiSpaceRegex = new Regex(@"[^\S\r\n]{2,}");
            if (multiSpaceRegex.IsMatch(FirstName))
                FirstName = multiSpaceRegex.Replace(FirstName, " ");
            if (multiSpaceRegex.IsMatch(LastName))
                LastName = multiSpaceRegex.Replace(LastName, " ");
        }

        public class Builder
        {
            private readonly UserBE _userBE;
            public Builder(string firstName, string lastName)
            {
                _userBE = new UserBE
                {
                    FirstName = firstName,
                    LastName = lastName,
                };
                _userBE.FullName = $"{_userBE.FirstName} {_userBE.LastName}";
            }

            public Builder WithUserID(int userID)
            {
                _userBE.UserID = userID;
                return this;
            }

            public UserBE Build()
            {
                _userBE.Validate();
                return _userBE;
            }
        }
    }
}
