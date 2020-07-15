using Guilherme.Domain.Interface.Repository;
using Guilherme.Service.Contracts.RequestResponse.User;
using Guilherme.Services.Implementation.Map;
using Guilherme.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guilherme.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly ITokenService _service;

        public UserService(IUserRepository repo, ITokenService service)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<UserResponse> LoginUserAsync(UserRequest request)
        {
            var user = await _repo.LoginUserAsync(request.Email);
            if (user == null)
            {
                throw new Exception("O e-mail informado não foi encontrado.");
            }

            bool validPassword = BCrypt.Net.BCrypt.Verify(request.Password, user?.Password);

            if (!validPassword)
            {
                throw new Exception("A senha informada está incorreta!");
            }

            var token = _service.GenerateToken(user);

            return user.ToResponse(token);
        }

        public async Task<UserResponse> AddUserAsync(UserRequest request)
        {
            var user = request.ToUser();
            await _repo.AddUserAsync(user);
            await _repo.SaveChangesAsync();

            return user.ToResponse();
        }

        public async Task<UserResponse> GetByUserIdAsync(Guid id)
        {
            return (await _repo.GetByUserIdAsync(id)).ToResponse();
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            return (await _repo.GetAllUsersAsync()).Select(r => r.ToResponse());
        }

        public async Task<UserResponse> UpdateUserAsync(Guid id, UserRequest request)
        {
            var user = await _repo.GetByUserIdAsync(id);

            if (user != null)
            {
                user = request.ToUpdateUser(user);
                await _repo.UpdateUserAsync(user);
                await _repo.SaveChangesAsync();

                return user.ToResponse();
            }

            return new UserResponse();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = _repo.GetByUserIdAsync(id);

            if (user == null)
            {
                throw new Exception($"Usuário com ID {id} não foi encontrado!");
            }

            await _repo.DeleteUserAsync(id);
            await _repo.SaveChangesAsync();
        }
    }
}