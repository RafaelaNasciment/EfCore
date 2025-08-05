namespace Infraestruture.Repository
{
    public class LivroRepository : EfRepository<Core.Entity.Livro>, Core.Repository.ILivroRepository
    {
        public LivroRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
