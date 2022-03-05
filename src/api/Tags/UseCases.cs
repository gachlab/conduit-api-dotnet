namespace Conduit.Tags
{
    public abstract class UseCases
    {
        public abstract Task<IEnumerable<Tag>> list();
    }
}