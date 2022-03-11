using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PracticeAPI.Infrastructure.Exceptions
{
    public class WebResponseException : WebException
    {
        private WebResponseException(string errorMessage) : base(errorMessage)
        {
        }
        public WebResponseException(HttpStatusCode responseCode, string errorMessage)
            : this($"Http{responseCode}:{Enum.GetName(typeof(HttpStatusCode), responseCode)} - {errorMessage}")
        {
        }
    }
}
