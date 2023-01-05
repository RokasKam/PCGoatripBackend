using System.ComponentModel.DataAnnotations;

namespace Academy.Core.Requests.Place;

public class UpdatePlaceRequest
{
    [Range(0, 5)]
    [Required]
    public double UserRating { get; set; }
}