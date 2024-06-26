using Models;
using Models.Users;

namespace IceCreamRecipe.Repositories.Users;

public interface IUserRepo {

    Task<User> Register(RegisterDto dto);

    Task<TokenDto> Login(LoginDto dto);

    Task<User> FindByUsername(string username);

    Task<User> GetUserDetail(String username);
    
    Task<PaginationRes<UserRes>> FindAll(PaginationReq pageReq);

    Task<object?> FindById(int id);

    Task<User> UpdateUser(User user, UserUpdateDto dto);

    Task ChangePassword(User user, ChangePasswordDto dto);
    
    Task<string> UpdateAvatar(User user, IFormFile avatar);

    Task ActivateUser(int userId);
    Task DeleteAvatar(User user);
    Task<bool> HandleUserActivation(int id);
}