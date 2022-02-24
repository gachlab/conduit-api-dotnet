namespace conduit_api_dotnet.Tags
{
    public abstract class UseCases
    {
        public abstract Task<IEnumerable<Tag>> list();
    }
}