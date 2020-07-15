using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guilherme.Domain.Core.DataModels;
using Guilherme.Domain.Entities;

namespace Guilherme.Domain.Interface.Repository
{
    public interface IUserRepository : IRepository<UserDto>
    {
        Task<User> LoginUserAsync(string email);

        Task<User> AddUserAsync(User model);

        Task<User> GetByUserIdAsync(Guid id);

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task UpdateUserAsync(User obj);

        Task DeleteUserAsync(Guid id);
    }
}