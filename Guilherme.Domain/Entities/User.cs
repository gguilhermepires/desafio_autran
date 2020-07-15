using System;
using System.ComponentModel.DataAnnotations;
using Guilherme.Domain.Core.Models;

namespace Guilherme.Domain.Entities
{
    public class User : Entity<User>
    {
        public User(Guid id, string name, string email, string password, string claim)
        {
            Id = id; 
            Name = name;
            Email = email;
            Password = password;
            Claim = claim;
        }

        protected User()
        {
            Id = Guid.NewGuid();
        }

        [Key] 
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Claim { get; private set; }

        public void AddBCryptPassword(string password)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}