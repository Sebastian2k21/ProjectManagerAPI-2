using ApplicationCore.Models;

namespace ProjectManagerApi.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}