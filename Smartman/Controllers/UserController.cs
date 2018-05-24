using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smartman.Models;
using Smartman.Repository;

namespace Smartman.Controllers
{
    [Route("api/Users")]
    public class UserController : Controller
    {

        private readonly UserRepository _userRepository;
        private const string Key = "11470670686776169484";

        protected UserController(SmartmanDbContext dbContext)
        {
            _userRepository = new UserRepository(dbContext);
        }

        [HttpPost]
        public IActionResult Register([FromBody]UserRegisterViewModel userRegisterViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        }
    }
}