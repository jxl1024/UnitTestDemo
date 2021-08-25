using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Model;

namespace UnitTest.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetEntity(Expression<Func<User, bool>> expression);

        Task<List<User>> GetAllUsers();

        Task<int> Add(User user);

        Task<int> Update(User entity, Expression<Func<User, object>>[] updatedProperties);

        Task<int> Delete(Guid id);
    }
}
