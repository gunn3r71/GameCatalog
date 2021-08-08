using System.Collections.Generic;
using GameCatalog.API.Models.Games.ViewModels;

namespace GameCatalog.API.Models.Categories.ViewModels
{
    public class CategoryWithGamesViewModel : CategoryViewModel
    {
        public List<GameWithDeveloperViewModel> Games { get; set; }
    }
}