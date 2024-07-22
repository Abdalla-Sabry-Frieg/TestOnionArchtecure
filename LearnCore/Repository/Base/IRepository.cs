using System.Linq.Expressions;

namespace LearnCore.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);

        //to find or search element by name or email or any thing
        // make this method overloading
        T SelectOne(Expression<Func<T, bool>> match);

        IEnumerable<T> FindAll();

        // to set a egger loading manually
        IEnumerable<T> FindAll(params string[] egars);

        // Asynchronization

       Task<T> FindByIdAsync(int id);

       Task<IEnumerable<T>> FindAllAsync();


        // to set a egger loading manually
        Task<IEnumerable<T>> FindAllAsync(params string[] egars);

        void AddOne(T MyItem);
        void UpdateOne(T MyItem);
        void DeleteOne(T MyItem);
        void AddList(IEnumerable<T> MyList);
        void UpdateList(IEnumerable<T> MyList);
        void DeleteList(IEnumerable<T> MyList);

    }
}
