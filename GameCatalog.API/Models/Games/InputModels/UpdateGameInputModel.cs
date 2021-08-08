using System;
using System.ComponentModel.DataAnnotations;

namespace GameCatalog.API.Models.Games.InputModels
{
    public class UpdateGameInputModel                             
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        public Guid Id { get; set; }
        [StringLength(40, ErrorMessage = "The name field {0} must be at least {2} and a maximum of {1} characters.", MinimumLength = 3)]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string Title { get; set; }
        [Range(minimum: 0.00, maximum: 100000.00, ConvertValueInInvariantCulture = true, ErrorMessage = "The field {0} must be between {2} and {1}")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "The field {0} is required.")]
        public Guid DeveloperId { get; set; }
        [Required(ErrorMessage = "The field {0} is required.")]
        public Guid CategoryId { get; set; }
    }
}