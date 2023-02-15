using Academy.Core.Responses.User;

namespace Academy.Core.Interfaces;

public interface IJwtService
{
    public JwtResponse BuildJwt(UserResponse user);
}