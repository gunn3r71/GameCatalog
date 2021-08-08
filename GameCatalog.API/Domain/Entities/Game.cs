using System;

namespace GameCatalog.API.Domain.Entities
{
    public class Game : Base
    {
        public Game()
        {
            Developer = new Developer();
            Category = new Category();
        }

        public string Title { get; set; }
        public double Price { get; set; }

        public Guid DeveloperId { get; set; }
        public Guid CategoryId { get; set; }
        public Developer Developer { get; set; }
        public Category Category { get; set; }
    }
}