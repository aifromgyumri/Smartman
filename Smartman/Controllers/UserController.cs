using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smartman.Models;
using Smartman.Repository;
using Smartman.ViewModels;

namespace Smartman.Controllers
{
    [Route("api/Users")]
    public class UserController : Controller
    {

        private readonly UserRepository _userRepository;
        private const string Key = "11470670686776169484";

        public UserController(SmartmanDbContext dbContext)
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
            if(_userRepository.FindByEmailandLoginandPhone(userRegisterViewModel.Email, userRegisterViewModel.Login, userRegisterViewModel.Phone))
            {
                ModelState.AddModelError("userExists", "User with this email or login already exists");
                return BadRequest(ModelState);
            }
            var user = new UserModel
            {
                Id = userRegisterViewModel.Id,
                Name = userRegisterViewModel.Name,
                Surname = userRegisterViewModel.Surname,
                Username = userRegisterViewModel.Username,
                Email = userRegisterViewModel.Email,
                Login = userRegisterViewModel.Login,
                Password = userRegisterViewModel.Password,
                Phone = userRegisterViewModel.Phone,
                Role = "user"
            };
            _userRepository.Add(user);
            return Ok();
        }

        [HttpPost("registeradmin")]
        public IActionResult RegisterAdmin([FromBody]UserRegisterViewModel userRegisterViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(_userRepository.FindByEmailandLoginandPhone(userRegisterViewModel.Email, userRegisterViewModel.Login, userRegisterViewModel.Phone))
            {
                ModelState.AddModelError("userExists", "User with this email or login already exists");
                return BadRequest(ModelState);
            }
            var user = new UserModel
            {
                Id=userRegisterViewModel.Id,
                Name=userRegisterViewModel.Name,
                Surname=userRegisterViewModel.Surname,
                Username=userRegisterViewModel.Username,
                Email=userRegisterViewModel.Email,
                Phone=userRegisterViewModel.Phone,
                Login=userRegisterViewModel.Login,
                Password=userRegisterViewModel.Password,
                Role = "admin"
            };
            _userRepository.Add(user);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = _userRepository.TestByEmailAndHashedPassword(loginViewModel.Email, loginViewModel.Password.PassToHash());
            if(user==null)
            {
                return NotFound();
            }
            var token = GenerateJwToken(user);
            return Ok(new { Token = token });
        }
    }
}