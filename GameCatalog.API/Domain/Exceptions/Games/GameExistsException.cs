using System;

namespace GameCatalog.API.Domain.Exceptions
{
    public class GameExistsException : Exception
    {
        public GameExistsException(string message = "The game already exists!") : base(message)
        {
        }
    }
}