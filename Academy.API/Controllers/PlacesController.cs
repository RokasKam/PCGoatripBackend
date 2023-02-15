using Academy.Core.Interfaces;
using Academy.Core.Requests.Place;
using Microsoft.AspNetCore.Mvc;

namespace Academy.API.Controllers;

public class PlaceController : BaseController 
{
    private readonly IPlaceService _placeService;
    
    public PlaceController(IPlaceService placeService)
    {
        _placeService = placeService;
    }
    
    [HttpGet]
    public IActionResult GetAll([FromQuery] PlacesParameters placesParameters)
    {
        return Ok(_placeService.GetAll(placesParameters));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_placeService.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePlaceRequest request)
    {
        return Ok(await _placeService.Create(request));
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, UpdatePlaceRequest request)
    {
        return Ok(_placeService.Update(id, request));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        _placeService.Delete(id);
        return Ok();
    }
    
    [HttpGet]
    public IActionResult GetSuggestions([FromQuery] SearchSuggestionsRequest searchSuggestionsRequest)
    {
        return Ok(_placeService.GetSuggestions(searchSuggestionsRequest));
    }
}