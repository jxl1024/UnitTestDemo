using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnitTest.EFCore.Context;
using UnitTest.Model;
using UnitTest.Repository;
using Xunit;

namespace UnitTest.Test
{
    [Trait("用户仓储层", "UserRepository")]
    public class UserRepositoryTest
    {
        [Fact]
        public async Task  Login_Get_Return()
        {
            // Arrange
            var _dbContext = await new InMemoryDbContextFactory().GetDbContext();
            var _userRepository = new UserRepository(_dbContext);

            // Act
            var users = _userRepository.GetAllUsers();

            // Assert
            Assert.NotNull(users);
        }

        [Fact]
        public async Task Login_Add_Return()
        {
            // Arrange
            var _dbContext = await new InMemoryDbContextFactory().GetDbContext();
            var _userRepository = new UserRepository(_dbContext);
            var user = new User()
            {
                ID=Guid.NewGuid(),
                LoginName="tom"
            };


            // Act
            int result = await _userRepository.Add(user);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task Login_Delete_Return()
        {
            // Arrange
            var _dbContext = await new InMemoryDbContextFactory().GetDbContext();
            var _userRepository = new UserRepository(_dbContext);

            Guid ID = Guid.Parse("75B29B45-E166-4665-8B09-BA73DE4C5FB0");
            // Act
            int result = await _userRepository.Delete(ID);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task Login_Put_Return()
        {
            // Arrange
            var _dbContext = await new InMemoryDbContextFactory().GetDbContext();
            var _userRepository = new UserRepository(_dbContext);
            var user = await _dbContext.Users.FirstOrDefaultAsync(p => p.ID == Guid.Parse("D0C28028-68E9-4DC6-A1EA-708207A66521"));
            user.LoginName = "tom";

            Expression<Func<User, object>>[] updatedServices =
            {
               p=>p.LoginName
            };

            // Act
            int result = await _userRepository.Update(user,updatedServices);

            // Assert
            Assert.Equal(1, result);
        }

        /// <summary>
        /// 内存数据库
        /// </summary>
        public class InMemoryDbContextFactory
        {
            public async Task<AppDbContext> GetDbContext()
            {
                var options = new DbContextOptionsBuilder<AppDbContext>()
                                .UseInMemoryDatabase(databaseName: "InMemoryArticleDatabase")
                                .Options;
                var dbContext = new AppDbContext(options);

                List<User> list = new List<User>()
                {
                    new User()
                    {
                        ID = Guid.Parse("75B29B45-E166-4665-8B09-BA73DE4C5FB0"),
                        LoginName = "admin",
                        Password = "1234"
                    },
                    new User()
                    {
                        ID = Guid.Parse("D0C28028-68E9-4DC6-A1EA-708207A66521"),
                        LoginName = "test",
                        Password = "123456"
                    }
                };

                await dbContext.Users.AddRangeAsync(list);


                await dbContext.SaveChangesAsync();
                return dbContext;
            }
        }
    }
}
