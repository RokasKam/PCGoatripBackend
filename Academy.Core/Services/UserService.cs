using Academy.Core.Interfaces;
using Academy.Core.Requests.Place;
using Academy.Core.Responses.Places;
using Academy.Core.Responses.User;
using Academy.Domain.Entities;
using AutoMapper;

namespace Academy.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public UserResponse GetById(Guid id)
    {
        var user = _userRepository.GetById(id);
        var response = _mapper.Map<UserResponse>(user);
        return response;
    }
    public List<PlaceResponse> GetAllUserPlaces(Guid userId, PlacesParameters placesParameters)
    {
        var places = _userRepository.GetAllPlacesByUser(userId, placesParameters);
        var placesResponseList = places.Select(x => _mapper.Map<PlaceResponse>(x)).ToList();

        return placesResponseList;
    }

    public void AddLikedPlace(Guid userId, Guid placeId)
    {
        _userRepository.PostUserPlace(userId, placeId);
    }

    public void RemoveLikedPlace(Guid userId, Guid placeId)
    {
        _userRepository.DeleteUserPlace(userId, placeId);
    }
}