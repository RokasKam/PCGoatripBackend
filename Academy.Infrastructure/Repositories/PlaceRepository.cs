using Academy.Core.Interfaces;
using Academy.Core.Requests.Place;
using Academy.Domain.Entities;
using Academy.Domain.Exceptions;
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
    
    public Place? GetByName(string name)
    {
        var place = _dbContext.Places.FirstOrDefault(x => x.PlaceName == name);

        return place;
    }
    
    public IEnumerable<Place> GetAll(PlacesParameters placesParameters)
    {
        
        IQueryable<Place> entities = _dbContext.Places;

        if (placesParameters.FilteringCategory != Category.All)
        {
            entities = entities
                .Where(i => i.Category == placesParameters.FilteringCategory);
        }
        if (placesParameters.SearchPhrase != "")
        {
            entities = entities
                .Where(x => x.PlaceName.ToLower().Contains(placesParameters.SearchPhrase.ToLower()));
        }
        
        entities = entities
            .OrderByDescending(x => x.Rating)
            .Skip((placesParameters.PageNumber - 1) * placesParameters.PageSize)
            .Take(placesParameters.PageSize);

        return entities.ToList();
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
            throw new ValidationException("Place not found");
        }

        _dbContext.Places.Remove(place);
        _dbContext.SaveChanges();
    }

    public IEnumerable<string> GetSuggestions(SearchSuggestionsRequest searchSuggestionsRequest)
    {
        var searchPhrase = searchSuggestionsRequest.SearchPhrase.ToLower();
        var suggestions = _dbContext.Places
            .Where(x => x.PlaceName.ToLower().Contains(searchPhrase))
            .Select(x => x.PlaceName)
            .ToList();
        return suggestions;
    }
}