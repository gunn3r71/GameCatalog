using System;
using System.ComponentModel.DataAnnotations;

namespace GameCatalog.API.Models.Categories.InputModels
{
    public class UpdateCategoryInputModel
    {
        public Guid Id { get; set; }
        [StringLength(30, ErrorMessage = "The name field {0} must be at least {2} and a maximum of {1} characters.", MinimumLength = 3)]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string Name { get; set; }
    }
}