using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitTest.IRepository;
using UnitTest.IService;
using UnitTest.Model;

namespace UnitTest.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Add(User user)
        {
            var entity = await _userRepository.GetEntity(p => p.LoginName == user.LoginName);
            if(null != entity)
            {
                return 0;
            }
            else
            {
                return await _userRepository.Add(user);
            }
          
        }

        public async Task<int> Delete(Guid id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<int> Update(User user)
        {
            var entity = await _userRepository.GetEntity(p => p.ID == user.ID);
            if (null != entity)
            {
                entity.LoginName = user.LoginName;
                entity.Password = user.Password;
                Expression<Func<User, object>>[] updatedServices =
                {
                   p=>p.LoginName
                };
                return await _userRepository.Update(entity, updatedServices);

            }
            else
            {
                return 0;
            }

        }
    }
}
