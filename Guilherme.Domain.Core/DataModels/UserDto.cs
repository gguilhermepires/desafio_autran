using System;
using System.ComponentModel.DataAnnotations;

namespace Guilherme.Domain.Core.DataModels
{
    public class UserDto
    {
        public UserDto(string name, string email, string password, string claim)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            Claim = claim;
        }
        
        public UserDto(Guid id, string name, string email, string password, string claim)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Claim = claim;
        }

        [Key] 
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Claim { get; set; }
    }
}