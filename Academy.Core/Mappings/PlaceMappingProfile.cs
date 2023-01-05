using Academy.Core.Requests.Place;
using Academy.Core.Responses.Places;
using Academy.Domain.Entities;
using AutoMapper;

namespace Academy.Core.Mappings;

public class PlaceMappingProfile : Profile
{
    public PlaceMappingProfile()
    {
        CreateMap<CreatePlaceRequest, Place>();
        CreateMap<Place, PlaceResponse>();
    }
}