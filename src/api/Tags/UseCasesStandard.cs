namespace Conduit.Tags
{
    public partial class UseCasesStandard : UseCases
    {
        private readonly Repository tags;
        public UseCasesStandard(Repository tags)
        {
            this.tags = tags;
        }

        public override Task<IEnumerable<Tag>> list()
        {
            return tags.find();
        }

    }
}