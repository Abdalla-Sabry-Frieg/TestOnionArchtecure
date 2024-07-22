using LearnCore.Models;

namespace LearnCore.Repository.Base
{
    public interface IUnitOfWork : IDisposable // IDisposable => used to remove space from ram when put instance from some classes
    {
        IRepository<Category> Categories {  get; }
        IRepository<Item> Items {  get; }
       IBookRepository Books {  get; }

        // to return number of Unit which has been commit succesfully
        int CommitChanges();

    }
}
