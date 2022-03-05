using static Conduit.Users.UseCases;

namespace Conduit.Users
{
    public abstract class Repository
    {
        public abstract Task<User> findOne(string id);
    }

    public class User
    {
        public string? email { get; set; }
        public string? token { get; set; }
        public string? username { get; set; }
        public string? bio { get; set; }
        public object? image { get; set; }
    }

}