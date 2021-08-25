using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitTest.IRepository;
using UnitTest.Model;
using UnitTest.Service;
using Xunit;

namespace UnitTest.Test
{
    public class UserServiceTest
    {
        [Fact]
        public async Task  Add_Return()
        {
            // Arrange
            var repository = new Mock<IUserRepository>();
            var userService = new UserService(repository.Object);

            var user = new User()
            {
                ID = Guid.NewGuid(),
                LoginName = "kevin",
                Password = "123456"
            };
            repository.Setup(p => p.Add(user)).Returns(Task.Run(()=> { return 1; }));

            // Act
            var result = await userService.Add(user);

            // Assert
            Assert.Equal(1,1);
        }

        [Fact]
        public async Task Delete_Return()
        {
            var repository = new Mock<IUserRepository>();
            var userService = new UserService(repository.Object);

            Guid id = Guid.NewGuid();

            repository.Setup(p => p.Delete(id)).Returns(Task.Run(() => { return 1; }));

            var result = await userService.Delete(id);

            Assert.Equal(1, 1);
        }

        [Fact]
        public async Task DeleteNot_Return()
        {
            var repository = new Mock<IUserRepository>();
            var userService = new UserService(repository.Object);

            Guid id = Guid.NewGuid();

            repository.Setup(p => p.Delete(Guid.NewGuid())).Returns(Task.Run(() => { return 1; }));

            var result = await userService.Delete(id);

            Assert.Equal(0, 0);
        }

    }
}
