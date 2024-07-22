using LearnCore.Data;
using LearnCore.Models;
using LearnCore.Repository.Base;

namespace LearnCore.Repository
{
    public class BookRepository : MainRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;

        }
        private readonly ApplicationDbContext _context;

        public void GetName(Book book)
        {
            throw new NotImplementedException();
        }

        public void GetSalary(Book book)
        {
            throw new NotImplementedException();
        }

        public void SetPayRoll(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
