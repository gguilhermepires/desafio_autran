using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guilherme.Data.Context;
using Guilherme.Domain.Entities;
using Guilherme.Service.Contracts.RequestResponse.User;

namespace Guilherme.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> LoginUserAsync(UserRequest request);

        Task<UserResponse> AddUserAsync(UserRequest request);

        Task<UserResponse> GetByUserIdAsync(Guid id);

        Task<IEnumerable<UserResponse>> GetAllAsync();

        Task<UserResponse> UpdateUserAsync(Guid id, UserRequest request);

        Task DeleteUserAsync(Guid id);
    }
}