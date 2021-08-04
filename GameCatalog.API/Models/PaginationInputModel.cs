using System.ComponentModel.DataAnnotations;

namespace GameCatalog.API.Models
{
    public class PaginationInputModel
    {
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        [Range(minimum: 1, maximum: 50, ConvertValueInInvariantCulture = true, ErrorMessage = "The field {0} must be between {2}")]
        public int Amount { get; set; } = 1;
    }
}