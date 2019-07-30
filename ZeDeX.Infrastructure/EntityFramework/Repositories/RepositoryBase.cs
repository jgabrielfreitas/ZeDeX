namespace ZeDeX.Infrastructure.EntityFramework.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly ZedexContext _context;

        public RepositoryBase(ZedexContext context)
        {
            _context = context;
        }
    }
}
