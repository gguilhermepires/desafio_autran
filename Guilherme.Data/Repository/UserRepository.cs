using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guilherme.Data.Context;
using Guilherme.Data.Mappings;
using Guilherme.Data.Repository.Base;
using Guilherme.Domain.Core.DataModels;
using Guilherme.Domain.Entities;
using Guilherme.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Guilherme.Data.Repository
{
    public class UserRepository : Repository<UserDto>, IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> LoginUserAsync(string email)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
            return user.ToUser();
        }
        public async Task<User> AddUserAsync(User model)
        {
            var userDto = model.ToUserDto();

            await base.AddAsync(userDto);

            return userDto.ToUser();
        }

        public async Task<User> GetByUserIdAsync(Guid id)
        {
            var userDtoFound = await base.GetByIdAsync(id);
            return userDtoFound.ToUser();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var usersDto = await base.GetAllAsync();

            return usersDto.Select(dto => dto.ToUser());
        }

        public async Task UpdateUserAsync(User model)
        {
            var userDto = model.ToUserUpdateDto();
            await base.UpdateAsync(userDto);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
    }
}