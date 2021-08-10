using System;

namespace GameCatalog.API.Domain.Exceptions.Developers
{
    public class DeveloperNotExistsException : Exception 
    {
        public DeveloperNotExistsException(string message = "The developer doesn't exist") : base(message)
        {
        }
    }
}