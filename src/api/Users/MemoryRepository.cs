
namespace Conduit.Users
{
    public class MemoryRepository : Repository
    {
        private IDictionary<string, User> dictionary;

        public MemoryRepository(IDictionary<string, User> dictionary)
        {
            this.dictionary = dictionary;
        }

        public override Task<User> findOne(string id)
        {
            return Task.FromResult(dictionary.FirstOrDefault(x => x.Key == id).Value);
        }
    }
}