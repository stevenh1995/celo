using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Celo.Common;
using Celo.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        [Route("api/GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Json(new
            {
                userList = _userService.GetAllUsers()
            });
        }

        [HttpGet]
        [Route("api/GetNumberOfUsers")]
        public IActionResult GetNumberOfUsers(int number)
        {
            return Json(new
            {
                userList = _userService.GetNumberOfUsers(number)
            });
        }

        [HttpGet]
        [Route("api/GetUserByName")]
        public IActionResult GetUserByName(string first, string last)
        {
            return Json(new
            {
                userList = _userService.GetUserByFirstOrLastName(first, last)
            });
        }

        [HttpGet]
        [Route("api/GetUserById")]
        public IActionResult GetUserById(int id)
        {
            return Json(new
            {
                userList = _userService.GetUserById(id)
            });
        }

        [HttpPost]
        [Route("api/AddUser")]
        public void AddUser([FromBody]User user)
        {
            if (user != null)
            {
                _userService.AddUser(user);
            }
        }

        [HttpPut]
        [Route("api/UpdateUser")]
        public void UpdateUser([FromBody]User user)
        {
            if (user != null)
            {
                _userService.UpdateUser(user);
            }
        }

        [HttpDelete]
        [Route("api/DeleteUser")]
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
