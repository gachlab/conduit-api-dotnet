namespace conduit_api_dotnet.Tags
{
    public class MemoryRepository : Repository
    {
        private readonly ICollection<Tag> data;
        public MemoryRepository(ICollection<Tag>? data)
        {
            this.data = data != null ? data : new List<Tag>();
        }
        public override Task<IEnumerable<Tag>> find()
        {
            return Task.FromResult<IEnumerable<Tag>>(data);
        }
    }
}