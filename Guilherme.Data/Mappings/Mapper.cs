using Guilherme.Domain.Core.DataModels;
using Guilherme.Domain.Entities;

namespace Guilherme.Data.Mappings
{
    public static class Mapper
    {
        public static User ToUser(this UserDto dto)
        {
            if (dto == null) return null;

            return new User
            (
                dto.Id,
                dto.Name,
                dto.Email,
                dto.Password,
                dto.Claim
            );
        }

        public static UserDto ToUserDto(this User model)
        {
            if (model == null) return null;

            return new UserDto
            (
                model.Name,
                model.Email,
                model.Password,
                model.Claim
            );
        } 
        
        public static UserDto ToUserUpdateDto(this User model)
        {
            if (model == null) return null;

            return new UserDto
            (
                model.Id,
                model.Name,
                model.Email,
                model.Password,
                model.Claim
            );
        }
    }
}