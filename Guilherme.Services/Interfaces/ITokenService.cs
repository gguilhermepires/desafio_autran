using Guilherme.Domain.Entities;

namespace Guilherme.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}