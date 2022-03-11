using Microsoft.AspNetCore.Mvc;
using PracticeAPI.Adapter.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAdapter _userAdapter;
        public UserController(IUserAdapter userAdapter)
        {
            _userAdapter = userAdapter;
        }
        [HttpPost]
        public async Task SaveName([FromQuery]string firstName, [FromQuery]string lastName)
        {
            await _userAdapter.SaveName(firstName, lastName);
        }
    }
}
