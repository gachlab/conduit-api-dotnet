namespace conduit_api_dotnet.Articles
{
    public partial class UseCasesStandard : UseCases
    {
        private readonly Repository articles;
        public UseCasesStandard(Repository articles)
        {
            this.articles = articles;
        }

        public override Task<IEnumerable<Article>> list()
        {
            return articles.find();
        }

    }
}