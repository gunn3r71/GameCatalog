using System;

namespace GameCatalog.API.Domain.Exceptions.Developers
{
    public class DeveloperExistsException : Exception 
    {
        public DeveloperExistsException(string message = "The developer already exists!") : base(message)
        {
        }
    }
}