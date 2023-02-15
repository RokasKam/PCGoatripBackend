using Academy.Core.Requests.Place;
using Academy.Domain.Entities;

namespace Academy.Core.Interfaces;

public interface IUserRepository
{
    User GetById(Guid id);
    User PostUser(User user);
    User? GetByEmailOrDefault(string email);
    IEnumerable<Place> GetAllPlacesByUser(Guid userId, PlacesParameters placesParameters);
    void PostUserPlace(Guid userId, Guid placeId);
    void DeleteUserPlace(Guid userId, Guid placeId);
}