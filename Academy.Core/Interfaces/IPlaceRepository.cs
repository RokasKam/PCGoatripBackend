using Academy.Domain.Entities;

namespace Academy.Core.Interfaces;

public interface IPlaceRepository
{
    Place? GetById(Guid id);

    IEnumerable<Place> GetAll();

    Place? Create(Place place);
    
    Place? Update(Place place);
    
    void Delete(Guid id);
}