using Academy.Domain.Entities;

namespace Academy.Core.Responses.Places;

public class PlaceResponse
{
    public Guid Id { get; set; }
    public string? PlaceName { get; set; }
    public string? PhotoUrl { get; set; }
    public Category Category { get; set; }
    public int PeopleAmountFrom { get; set; }
    public int PeopleAmountTo { get; set; }
    public double PriceFrom { get; set; }
    public double PriceTo { get; set; }
    public double VisitDurationFrom { get; set; }
    public double VisitDurationTo { get; set; }
    public double Latitude { get; set; }
    public double Longtitude { get; set; }
    public double Rating { get; set; }
}