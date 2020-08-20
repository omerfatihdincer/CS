using CS.EntityFrameworkCore.EntityFrameworkCore;

namespace CS.EntityFrameworkCore.Seed
{

    public class InitialDbBuilder
    {
        private readonly CSDbContext _context;

        public InitialDbBuilder(CSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultDbCreator(_context).Create();
            _context.SaveChanges();
        }
    }
}
