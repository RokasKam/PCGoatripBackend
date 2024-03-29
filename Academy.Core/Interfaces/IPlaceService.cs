using Academy.Core.Requests.Place;
using Academy.Core.Responses.Places;

namespace Academy.Core.Interfaces;

public interface IPlaceService
{
    List<PlaceResponse> GetAll(PlacesParameters placesParameters);

    PlaceResponse? GetById(Guid id);

    Task<PlaceResponse> Create(CreatePlaceRequest place);

    PlaceResponse Update(Guid id, UpdatePlaceRequest place);

    void Delete(Guid id);

    List<string> GetSuggestions(SearchSuggestionsRequest searchSuggestionsRequest);
}