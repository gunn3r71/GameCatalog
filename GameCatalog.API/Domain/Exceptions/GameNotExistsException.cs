using System;

namespace GameCatalog.API.Domain.Exceptions
{
    public class GameNotExistsException : Exception
    {
        public GameNotExistsException(string message = "The game doesn't exist") : base(message)
        {
        }
    }
}