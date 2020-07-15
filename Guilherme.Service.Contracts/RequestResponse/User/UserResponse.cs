using System;

namespace Guilherme.Service.Contracts.RequestResponse.User
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Claim { get; set; }
        public string Token { get; set; }
    }
}