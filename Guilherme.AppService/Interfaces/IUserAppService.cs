using System;
using System.Collections.Generic;
using Guilherme.Service.Contracts.RequestResponse.User;
using System.Net.Http;
using System.Threading.Tasks;
using Guilherme.Service.Contracts.RequestResponse.Base;
using Guilherme.Data.Context;

namespace Guilherme.AppService.Interfaces
{
    public interface IUserAppService
    {
        Task<ResponseMessage<UserResponse>> LoginUserAsync(UserRequest request);

        Task<ResponseMessage<UserResponse>> AddUserAsync(UserRequest request);

        Task<ResponseMessage<UserResponse>> GetByUserIdAsync(Guid id);

        Task<ResponseMessage<IEnumerable<UserResponse>>> GetAllUsersAsync();

        Task<ResponseMessage<UserResponse>> UpdateUserAsync(Guid id, UserRequest request);

        Task<ResponseMessage<string>> DeleteUserAsync(Guid id);
    }
}