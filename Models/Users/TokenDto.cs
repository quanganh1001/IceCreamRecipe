namespace Models.Users;

public class TokenDto
{

    public required UserRes User { get; set; }

    public required string AccessToken { get; set; }
    
}