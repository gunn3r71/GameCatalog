using System;
using GameCatalog.API.Models.Categories.ViewModels;
using GameCatalog.API.Models.Developers.ViewModels;

namespace GameCatalog.API.Models.Games.ViewModels
{
    public class GameWithDeveloperViewModel : GameViewModel
    {
        public DeveloperViewModel Developer { get; set; }
    }
}