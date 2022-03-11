using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeAPI.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public async Task SaveName([FromQuery]string firstName, [FromQuery]string lastName)
        {
        }
    }
}
