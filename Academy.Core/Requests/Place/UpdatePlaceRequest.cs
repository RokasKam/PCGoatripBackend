using System.ComponentModel.DataAnnotations;

namespace Academy.Core.Requests.Place;

public class UpdatePlaceRequest
{
    [Range(0, 5, ErrorMessage = "The chosen rating must be between 0 and 5")]
    [Required(ErrorMessage = "The rating must be chosen")]
    public double UserRating { get; set; }
}