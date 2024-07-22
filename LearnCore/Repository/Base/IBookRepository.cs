using LearnCore.Models;

namespace LearnCore.Repository.Base
{
    public interface IBookRepository  :IRepository<Book>
    {
        void SetPayRoll(Book book);
        void GetName(Book book);
        void GetSalary(Book book);
    }
}
