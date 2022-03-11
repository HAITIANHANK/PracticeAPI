using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeAPI.Infrastructure.Exceptions;
using System.Text;

namespace PracticeAPI.Controllers
{
    public abstract class BaseController : Controller
    {
        protected async Task HandleWebResponseException(WebResponseException ex)
        {
            base.HttpContext.Response.StatusCode = (int)ex.ResponseCode;
            byte[] responseData = Encoding.UTF8.GetBytes(ex.Message);
            await base.HttpContext.Response.Body.WriteAsync(responseData, 0, responseData.Length);
        }
    }
}
