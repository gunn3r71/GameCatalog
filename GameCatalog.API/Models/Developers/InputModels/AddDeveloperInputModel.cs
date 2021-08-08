using System.ComponentModel.DataAnnotations;

namespace GameCatalog.API.Models.Developers.InputModels
{
    public class AddDeveloperInputModel
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        public string Name { get; set; }
    }
}