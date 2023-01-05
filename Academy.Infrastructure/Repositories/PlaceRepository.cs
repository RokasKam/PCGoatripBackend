using Academy.Core.Interfaces;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class PlaceRepository : IPlaceRepository
{
    private readonly AcademyDataContext _dbContext;

    public PlaceRepository(AcademyDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Place? GetById(Guid id)
    {
        var place = _dbContext.Places.FirstOrDefault(x => x.Id == id);

        return place;
    }

    public IEnumerable<Place> GetAll()
    {
        var entities = _dbContext.Places.ToList();

        return entities;
    }

    public Place? Create(Place place)
    {
        place.Id = Guid.NewGuid();
        place.Rating = 0;
        place.RatingAmount = 0;
        _dbContext.Places.Add(place);
        _dbContext.SaveChanges();

        return place;
    }

    public Place? Update(Place place)
    {
        var local = _dbContext.Places
            .Local
            .FirstOrDefault(oldEntity => oldEntity.Id == place.Id);

        if (local != null)
        {
            _dbContext.Entry(local).State = EntityState.Detached;
        }

        _dbContext.Entry(place).State = EntityState.Modified;
        _dbContext.SaveChanges();

        return place;
    }

    public void Delete(Guid id)
    {
        var place = _dbContext.Places.SingleOrDefault(entity => entity.Id == id);

        if (place is null)
        {
            throw new Exception("Place not found");
        }

        _dbContext.Places.Remove(place);
        _dbContext.SaveChanges();
    }
}