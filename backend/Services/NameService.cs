using backend.Models;
using backend.Contracts;

namespace backend.Services
{
    public class NameService : INameService
    {
        public Name Get()
        {
            return new Name() { name = "World" };
        }
    }
}
