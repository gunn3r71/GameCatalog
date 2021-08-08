using System.ComponentModel.DataAnnotations;

namespace GameCatalog.API.Models.Games.InputModels
{
    public class AddGameInputModel
    {
        [StringLength(40, ErrorMessage = "The name field {0} must be at least {2} and a maximum of {1} characters.", MinimumLength = 3)]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string Title { get; set; }
        [StringLength(100, ErrorMessage = "The name field {0} must be at least {2} and a maximum of {1} characters.", MinimumLength = 2)]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string Developer { get; set; }
        [Range(minimum:0.00, maximum:100000.00, ConvertValueInInvariantCulture = true, ErrorMessage = "The field {0} must be between {2} and {1}")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public double Price { get; set; }
    }
}