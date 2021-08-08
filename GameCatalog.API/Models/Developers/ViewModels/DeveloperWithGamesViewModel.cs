using System;
using System.Collections.Generic;
using GameCatalog.API.Models.Games.ViewModels;

namespace GameCatalog.API.Models.Developers.ViewModels
{
    public class DeveloperWithGamesViewModel : DeveloperViewModel
    {
        public List<GameViewModel> Games { get; set; }
    }
}