using LearnCore.Data;
using LearnCore.Models;
using LearnCore.Repository.Base;

namespace LearnCore.Repository
{
    public class UnitOfWork :IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categories = new MainRepository<Category>(_context);
            Items = new MainRepository<Item>(_context); 
            Books = new BookRepository(_context);
            
        }
        private ApplicationDbContext _context;

        public IRepository<Category> Categories { get; private set; }

        public IRepository<Item> Items { get; private set; }

        public IBookRepository Books { get; private set; }

        public int CommitChanges()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
