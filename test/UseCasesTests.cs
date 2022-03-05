using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;


namespace Conduit.Users
{
    public class UseCasesTests
    {
        [Fact]
        public async Task shouldReturnAValidProfileFromAnExistingUserAsync()
        {
            // Given
            var existingUserId = "test@gmail.com";
            var existingUser = new User() { email = existingUserId, username = "test", bio = "test", image = "test" };
            var repository = new MemoryRepository(new Dictionary<string, User>() { [existingUserId] = existingUser });
            var expectedResult = new UseCases.Profile() { username = existingUser.username, bio = existingUser.bio, image = existingUser.image.ToString() };
            var useCases = new UseCasesStandard(repository);
            // When
            var actualResult = await useCases.profile(existingUserId);
            // Then
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public async void shouldReturnNotFoundExceptionMessageWhenAskingNotExistingProfile()
        {
            // Given
            var nonExistingUserId = "test@gmail.com";
            var existingUser = new User() { email = "abc@blah.com", username = "test", bio = "test", image = "test" };
            var repository = new MemoryRepository(new Dictionary<string, User>() { [nonExistingUserId] = existingUser });
            var expectedResult = new UseCases.Profile() { username = existingUser.username, bio = existingUser.bio, image = existingUser.image.ToString() };
            var useCases = new UseCasesStandard(repository);
            // When
            var actualResult = await useCases.profile(nonExistingUserId);
            // Then
            Assert.Equal(expectedResult, actualResult);
        }
    }
}