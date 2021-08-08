using System;
using GameCatalog.API.Models.Categories.ViewModels;
using GameCatalog.API.Models.Developers.ViewModels;

namespace GameCatalog.API.Models.Games.ViewModels
{
    public class GameViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}