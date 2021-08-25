using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitTest.EFCore.Context;
using UnitTest.IRepository;
using UnitTest.Model;

namespace UnitTest.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<int> Add(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid id)
        {
            var user =await _appDbContext.Users.FirstOrDefaultAsync(p => p.ID == id);
            _appDbContext.Users.Remove(user);
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<User> GetEntity(Expression<Func<User, bool>> expression)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(expression);
        }

        public async Task<int> Update(User entity, Expression<Func<User, object>>[] updatedProperties)
        {
            _appDbContext.Set<User>().Attach(entity);
            if (updatedProperties.Any())
            {
                foreach (var property in updatedProperties)
                {
                    _appDbContext.Entry(entity).Property(property).IsModified = true;
                }
            }
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
