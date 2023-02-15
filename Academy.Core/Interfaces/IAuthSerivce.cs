using Academy.Core.Requests.User;
using Academy.Core.Responses.User;

namespace Academy.Core.Interfaces;
public record HashPasswordResponse(byte[] PasswordHash, byte[] PasswordSalt);

public interface IAuthService
{
    HashPasswordResponse HashPassword(string password);

    UserResponse Login(LoginRequest login);

    RegistrationResponse Register(RegisterRequest register);
    
}