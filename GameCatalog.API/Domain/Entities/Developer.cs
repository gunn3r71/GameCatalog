using System.Collections.Generic;

namespace GameCatalog.API.Domain.Entities
{
    public class Developer : Base
    {
        public Developer()
        {
            Games = new List<Game>();
        }

        public string Name { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}