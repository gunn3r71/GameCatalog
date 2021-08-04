using System;

namespace GameCatalog.API.Domain.Entities
{
    public class Game : Base
    {
        public string Title { get; set; }
        public string Developer { get; set; }
        public double Price { get; set; }
    }
}