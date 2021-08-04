using System;

namespace GameCatalog.API.Domain.Entities
{
    public abstract class Base
    {
        public Base()
        {
            Id = Guid.NewGuid();
            Status = true;
            CreatedAt = DateTime.UtcNow.AddHours(-3);
            UpdatedAt = DateTime.UtcNow.AddHours(-3);
        }

        public Guid Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}