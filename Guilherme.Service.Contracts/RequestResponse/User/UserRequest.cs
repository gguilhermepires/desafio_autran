using System;

namespace Guilherme.Service.Contracts.RequestResponse.User
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Claim { get; set; }
    }
}