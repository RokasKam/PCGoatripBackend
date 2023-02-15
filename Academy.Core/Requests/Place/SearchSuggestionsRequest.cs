using System.ComponentModel.DataAnnotations;

namespace Academy.Core.Requests.Place;

public class SearchSuggestionsRequest
{
    [Required(ErrorMessage = "Search Phrase is required")]
    [MinLength(3, ErrorMessage = "Search phrase must be longer than 3 characters")]
    public string SearchPhrase { get; set; }
}