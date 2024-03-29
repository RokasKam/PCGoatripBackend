using Academy.Core.Interfaces;
using Academy.Core.Requests.Place;
using Academy.Core.Responses.Places;
using Academy.Domain.Entities;
using Academy.Domain.Exceptions;
using AutoMapper;

namespace Academy.Core.Services;

public class PlaceService : IPlaceService
{
    private readonly IPlaceRepository _placeRepository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;
    
    public PlaceService(IPlaceRepository placeRepository, IMapper mapper, IImageService imageService)
    {
        _placeRepository = placeRepository;
        _mapper = mapper;
        _imageService = imageService;
    }
    public List<PlaceResponse> GetAll(PlacesParameters placesParameters)
    {
        var places = _placeRepository.GetAll(placesParameters);
        var placesResponseList = places.Select(x => _mapper.Map<PlaceResponse>(x)).ToList();

        return placesResponseList;
    }

    public PlaceResponse? GetById(Guid id)
    {
        var place = _placeRepository.GetById(id);
        var placeResponse = _mapper.Map<PlaceResponse>(place);

        return placeResponse;
    }

    public async Task<PlaceResponse> Create(CreatePlaceRequest place)
    {
        var requestPlace = _mapper.Map<Place>(place);
        if (_placeRepository.GetByName(place.PlaceName) != null)
        {
            throw new ValidationException("Place with this name exist");
        }
        Stream imageStream = _imageService.ConvertBase64ToStream(place.PhotoBase64);
        string imageFromFirebase = await _imageService.UploadImage(imageStream, place.PlaceName);
        requestPlace.PhotoUrl = imageFromFirebase;
        var createdPlace = _placeRepository.Create(requestPlace);
        var response = _mapper.Map<PlaceResponse>(createdPlace);
        return response;
    }

    public PlaceResponse Update(Guid id, UpdatePlaceRequest place)
    {
        var placeToUpdate = _placeRepository.GetById(id);
        if (placeToUpdate is null)
        {
            throw new ValidationException("Place with provided id does not exist");
        }
        
        if (placeToUpdate.RatingAmount == 0)
        {
            placeToUpdate.Rating = place.UserRating;
            placeToUpdate.RatingAmount = 1;
        }
        else
        {
            placeToUpdate.Rating = (placeToUpdate.Rating * placeToUpdate.RatingAmount + place.UserRating) 
                                   / (placeToUpdate.RatingAmount + 1);
            placeToUpdate.RatingAmount += 1;
        }
        
        var updatedPlace = _placeRepository.Update(placeToUpdate);
        var updatePlaceResponse = _mapper.Map<PlaceResponse>(updatedPlace);
        return updatePlaceResponse;

    }

    public void Delete(Guid id)
    {
        _placeRepository.Delete(id);
    }

    public List<string> GetSuggestions(SearchSuggestionsRequest searchSuggestionsRequest)
    {
        var suggestions  = _placeRepository.GetSuggestions(searchSuggestionsRequest).ToList();
        return suggestions;
    }
}