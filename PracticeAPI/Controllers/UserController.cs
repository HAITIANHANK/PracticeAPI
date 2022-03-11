using Microsoft.AspNetCore.Mvc;
using PracticeAPI.Adapter.Contracts;
using PracticeAPI.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeAPI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserAdapter _userAdapter;
        public UserController(IUserAdapter userAdapter)
        {
            _userAdapter = userAdapter;
        }
        [HttpPost]
        public async Task SaveName([FromQuery]string firstName, [FromQuery]string lastName)
        {
            try
            {
                await _userAdapter.SaveName(firstName, lastName);
            }
            catch (WebResponseException webEx)
            {
                await base.HandleWebResponseException(webEx);
            }
            catch 
            {
                throw;
            }
        }
    }
}
