using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitTest.API.Controllers;
using UnitTest.IService;
using UnitTest.Model;
using Xunit;

namespace UnitTest.Test
{
    public class UserControllerTest
    {
        [Fact]
        public async Task Add_Return()
        {
            var userService = new Mock<IUserService>();

            UsersController usersController = new UsersController(userService.Object);

            var user = new User()
            {
                ID = Guid.NewGuid(),
                LoginName = "kevin",
                Password = "123456"
            };
            userService.Setup(p => p.Add(user)).Returns(Task.Run(() => { return 1; }));

            var result = await usersController.Post(user);

            Assert.Equal(1, 1);
        }


        [Fact]
        public async Task Delete_Return()
        {
            var userService = new Mock<IUserService>();

            UsersController usersController = new UsersController(userService.Object);

            Guid id = Guid.NewGuid();

            userService.Setup(p => p.Delete(id)).Returns(Task.Run(() => { return 1; }));

            var result = await usersController.Delete(id);

            Assert.Equal(1, 1);
        }

        [Fact]
        public async Task DeleteNot_Return()
        {
            var userService = new Mock<IUserService>();

            UsersController usersController = new UsersController(userService.Object);

            Guid id = Guid.NewGuid();

            userService.Setup(p => p.Delete(Guid.NewGuid())).Returns(Task.Run(() => { return 1; }));

            var result = await usersController.Delete(id);

            Assert.Equal(0, 0);
        }
    }
}
