using System.ComponentModel.DataAnnotations;
using Academy.Domain.Entities;

namespace Academy.Core.Requests.Place;

public class CreatePlaceRequest : IValidatableObject
{
    [Required]
    public string? PlaceName { get; set; }
    [Required]
    [RegularExpression( @"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$")]
    public string? PhotoBase64 { get; set; }
    [Required]
    [EnumDataType(typeof(Category))]
    public Category Category { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int PeopleAmountFrom { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int PeopleAmountTo { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public double PriceFrom { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public double PriceTo { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public double VisitDurationFrom { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public double VisitDurationTo { get; set; }
    [Required]
    public double Latitude { get; set; }
    [Required]
    public double Longtitude { get; set; }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (PeopleAmountFrom > PeopleAmountTo)
        {
            yield return new ValidationResult("The lowest amount of people must be lower or equal than the highest amount of people");
        }
        if (PriceFrom > PriceTo)
        {
            yield return new ValidationResult("The lowest cost must be lower or equal than the highest cost");
        }
        if (VisitDurationFrom > VisitDurationTo)
        {
            yield return new ValidationResult("The shortest visit duration must be shorter or equal than the longest visit duration");
        }
    }
}