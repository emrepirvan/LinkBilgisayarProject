using LinkBilgisayarProject.Core.UnitOfWorks;

namespace LinkBilgisayarProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LinkAppDbContext _context;

        public UnitOfWork(LinkAppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
