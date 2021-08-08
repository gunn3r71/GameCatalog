using System;
using System.ComponentModel.DataAnnotations;

namespace GameCatalog.API.Models.Developers.InputModels
{
    public class UpdateDeveloperInputModel
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        public Guid Id { get; set; }
        [StringLength(100,ErrorMessage = "The name field {0} must be at least {2} and a maximum of {1} characters.", MinimumLength = 2)]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string Name { get; set; }
    }
}