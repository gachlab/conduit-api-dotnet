namespace conduit_api_dotnet.Tags
{
    public abstract class Repository
    {
        public abstract Task<IEnumerable<Tag>> find();

    }
}