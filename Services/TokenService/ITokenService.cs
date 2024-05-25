
using Models.Users;

namespace Services.TokenService;

public interface ITokenService
{
    string CreateToken(User user);
}