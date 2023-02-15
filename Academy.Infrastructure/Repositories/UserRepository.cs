using Academy.Core.Interfaces;
using Academy.Core.Requests.Place;
using Academy.Domain.Entities;
using Academy.Domain.Exceptions;
using Academy.Infrastructure.Data;

namespace Academy.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AcademyDataContext _dbContext;

    public UserRepository(AcademyDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User GetById(Guid id)
    {
        var user = _dbContext.Users.First(u => u.Id == id);

        return user;
    }
    
    public User PostUser(User user)
    {
        user.Id = Guid.NewGuid();
        _dbContext.Users.Add(user); 
        _dbContext.SaveChanges();
        return user;
    }
    
    public User? GetByEmailOrDefault(string email)
    {
        var user =  _dbContext.Users.FirstOrDefault(u => u.Email == email);
        return user;
    }

    public IEnumerable<Place> GetAllPlacesByUser(Guid userId, PlacesParameters placesParameters)
    {
        IQueryable<Place> entities = _dbContext.UserPlaces
            .Where(x=>x.UserId == userId)
            .Select(x=> x.Place);
        
        entities = entities
            .OrderByDescending(x => x.Rating)
            .Skip((placesParameters.PageNumber - 1) * placesParameters.PageSize)
            .Take(placesParameters.PageSize);

        return entities.ToList();
    }

    public void PostUserPlace(Guid userId, Guid placeId)
    {
        var existingUserPlace = _dbContext.UserPlaces
            .FirstOrDefault(x => x.UserId == userId && x.PlaceId == placeId);
        if (existingUserPlace is not null)
            throw new ConflictException("This place exists in your liked places list");
        
        var userPlace = new UserPlace()
        {
            UserId = userId,
            PlaceId = placeId,
        };
        _dbContext.UserPlaces.Add(userPlace); 
        _dbContext.SaveChanges();
    }
    
    public void DeleteUserPlace(Guid userId, Guid placeId)
    {
        var place = _dbContext.UserPlaces
            .SingleOrDefault(x => x.UserId == userId && x.PlaceId == placeId);

        if (place is null)
        {
            throw new ConflictException("This place does not exists in your liked places list");
        }

        _dbContext.UserPlaces.Remove(place);
        _dbContext.SaveChanges();
    }

}