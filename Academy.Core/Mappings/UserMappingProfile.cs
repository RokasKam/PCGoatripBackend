using Academy.Core.Requests.User;
using Academy.Core.Responses.User;
using Academy.Domain.Entities;
using AutoMapper;

namespace Academy.Core.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserResponse>();
        CreateMap<RegisterRequest, User>();
        CreateMap<LoginRequest, User>();
    }
}