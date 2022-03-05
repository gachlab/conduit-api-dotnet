using System;
using System.Threading.Tasks;

namespace Conduit.Users
{
    public class UseCasesStandard : UseCases
    {
        private readonly Repository repository;

        public UseCasesStandard(Repository repository)
        {
            this.repository = repository;
        }

        public override Task<User> details(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<Profile> follow(string currentUserId, string userToFollowId)
        {
            throw new NotImplementedException();
        }

        public override Task<User> login(UserLoginRequest user)
        {
            throw new NotImplementedException();
        }

        public override async Task<Profile> profile(string id)
        {
            var existingUser = await repository.findOne(id);

            return (new Profile()
            {
                bio = existingUser.bio,
                image = existingUser.image != null ? existingUser.image.ToString() : "",
                username = existingUser.username,
                following = false
            });
        }

        public override Task<User> registration(UserRegistrationRequest user)
        {
            throw new NotImplementedException();
        }

        public override Task<Profile> unfollow(string currentUserId, string userToUnfollowId)
        {
            throw new NotImplementedException();
        }

        public override Task<User> update(string id, UserUpdateRequest user)
        {
            throw new NotImplementedException();
        }
    }
}