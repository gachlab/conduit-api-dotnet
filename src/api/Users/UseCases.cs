using System.Threading.Tasks;

namespace Conduit.Users
{
    public abstract class UseCases
    {
        public abstract Task<User> login(UserLoginRequest user);

        public abstract Task<User> registration(UserRegistrationRequest user);
        public abstract Task<User> details(string id);
        public abstract Task<User> update(string id, UserUpdateRequest user);

        public abstract Task<Profile> profile(string id);

        public abstract Task<Profile> follow(string currentUserId, string userToFollowId);

        public abstract Task<Profile> unfollow(string currentUserId, string userToUnfollowId);


        public class Profile : IEquatable<Profile>
        {
            public string? username { get; set; }
            public string? bio { get; set; }
            public string? image { get; set; }
            public bool following { get; set; }

            public bool Equals(Profile? other)
            {

                return other != null ? this.username == other.username && this.bio == other.bio && this.image == other.image && this.following == other.following : false;

            }
        }

        public class UserLoginRequest
        {
        }

        public class UserRegistrationRequest
        {
        }

        public class UserUpdateRequest
        {
        }
    }
}