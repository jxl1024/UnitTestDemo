using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTest.IService;
using UnitTest.Model;

namespace UnitTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await _userService.GetAllUsers();
        }

        [HttpPost]
        public async Task<int> Post([FromBody]User entity)
        {
            return await _userService.Add(entity);
        }

        [HttpPut]
        public async Task<int> Put([FromBody] User entity)
        {
            return await _userService.Update(entity);
        }

        [HttpDelete]
        public async Task<int> Delete(Guid id)
        {
            return await _userService.Delete(id);
        }
    }
}
