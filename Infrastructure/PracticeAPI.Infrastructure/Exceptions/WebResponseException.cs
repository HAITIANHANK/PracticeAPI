using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PracticeAPI.Infrastructure.Exceptions
{
    public class WebResponseException : Exception
    {
        public HttpStatusCode ResponseCode;
        public new string Message;

        public WebResponseException(HttpStatusCode responseCode, string message)
        {
            ResponseCode = responseCode;
            Message = message;
        }
    }
}
