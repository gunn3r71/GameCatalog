using System;
using System.ComponentModel.DataAnnotations;

namespace GameCatalog.API.Models.Categories.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}