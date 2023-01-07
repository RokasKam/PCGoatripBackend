using Academy.Core.Requests.Place;
using Academy.Domain.Entities;

namespace Academy.Core.Interfaces;

public interface IPlaceRepository
{
    Place? GetById(Guid id);
    
    Place? GetByName(string name);
    
    IEnumerable<Place> GetAll(PlacesParameters placesParameters);

    Place? Create(Place place);
    
    Place? Update(Place place);
    
    void Delete(Guid id);
}