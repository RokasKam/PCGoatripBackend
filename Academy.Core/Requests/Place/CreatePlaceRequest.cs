using System.ComponentModel.DataAnnotations;
using Academy.Domain.Entities;

namespace Academy.Core.Requests.Place;

public class CreatePlaceRequest : IValidatableObject
{
    [Required(ErrorMessage = "The name of the place must be chosen")]
    public string? PlaceName { get; set; }
    
    [Required(ErrorMessage = "The photo of the place must be chosen")]
    [RegularExpression(@"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$", 
        ErrorMessage = "The photo of the place must be valid")]
    public string? PhotoBase64 { get; set; }
    
    [Required(ErrorMessage = "The category of the place must be chosen")]
    [EnumDataType(typeof(Category), ErrorMessage = "The category of the place must be valid")]
    public Category Category { get; set; }
    
    [Required(ErrorMessage = "The minimum amount of people per visit of the place must be written")]
    [Range(0, int.MaxValue, ErrorMessage = "The minimum amount of people per visit of the place cannot be negative")]
    public int PeopleAmountFrom { get; set; }
    
    [Required(ErrorMessage = "The maximum amount of people per visit of the place must be written")]
    [Range(0, int.MaxValue, ErrorMessage = "The maximum amount of people per visit of the place cannot be negative")]
    public int PeopleAmountTo { get; set; }
    
    [Required(ErrorMessage = "The minimum price per visit of the place must be written")]
    [Range(0, double.MaxValue, ErrorMessage = "The minimum price per visit of the place cannot be negative")]
    public double PriceFrom { get; set; }
    
    [Required(ErrorMessage = "The maximum price per visit of the place must be written")]
    [Range(0, double.MaxValue, ErrorMessage = "The maximum price per visit of the place cannot be negative")]
    public double PriceTo { get; set; }
    
    [Required(ErrorMessage = "The minimum spent time per visit of the place must be written")]
    [Range(0, double.MaxValue, ErrorMessage = "The minimum spent time per visit of the place cannot be negative")]
    public double VisitDurationFrom { get; set; }
    
    [Required(ErrorMessage = "The maximum spent time per visit of the place must be written")]
    [Range(0, double.MaxValue, ErrorMessage = "The maximum spent time per visit of the place cannot be negative")]
    public double VisitDurationTo { get; set; }
    
    [Required(ErrorMessage = "The location of the place must be chosen")]
    public double Latitude { get; set; }
    
    [Required(ErrorMessage = "The location of the place must be chosen")]
    public double Longtitude { get; set; }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Category == Category.All)
        {
            yield return new ValidationResult("The category of the place must be chosen");

        }
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