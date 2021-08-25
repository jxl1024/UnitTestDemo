using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Model;

namespace UnitTest.IService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<int> Add(User user);

        Task<int> Update(User user);

        Task<int> Delete(Guid id);
    }
}
