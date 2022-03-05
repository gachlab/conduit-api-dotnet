namespace Conduit.Tags
{
    public abstract class Repository
    {
        public abstract Task<IEnumerable<Tag>> find();

    }
}