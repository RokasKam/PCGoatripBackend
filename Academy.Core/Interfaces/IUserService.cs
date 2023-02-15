using Academy.Core.Requests.Place;
using Academy.Core.Responses.Places;
using Academy.Core.Responses.User;

namespace Academy.Core.Interfaces;

public interface IUserService
{
    UserResponse GetById(Guid id);
    
    List<PlaceResponse> GetAllUserPlaces(Guid userId, PlacesParameters placesParameters);

    void AddLikedPlace(Guid userId, Guid placeId);
    
    void RemoveLikedPlace(Guid userId, Guid placeId);
}