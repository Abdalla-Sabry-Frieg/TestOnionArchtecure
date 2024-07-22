using LearnCore.Data;
using LearnCore.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LearnCore.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(ApplicationDbContext Context) 
        {
            this.Context = Context;
        }

        protected ApplicationDbContext Context;

        public T FindById(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return Context.Set<T>().SingleOrDefault(match);
        }
        public IEnumerable<T> FindAll()
        {
            return Context.Set<T>().ToList();
        }

        // Asynchronization

        public async Task<T> FindByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

       
        public async Task<IEnumerable<T>> FindAllAsync()
        {
           return await Context.Set<T>().ToListAsync();
        }
        // immplement the interface methods to Add Eggar loading

        public IEnumerable<T> FindAll(params string[] egars)
        {
           IQueryable<T> query = Context.Set<T>();

            if(egars.Length>0) 
            {
                foreach(var egger in egars) 
                {
                    query = query.Include(egger);
                }
               
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] egars)
        {
            IQueryable<T> query = Context.Set<T>();

            if(egars.Length > 0)
            {
                foreach(var egger in egars)
                {
                    query = query.Include(egger);
                }
            }

            return await query.ToListAsync();
        }

        public void AddOne(T MyItem)
        {
            Context.Set<T>().Add(MyItem);
            Context.SaveChanges();
        }

        public void UpdateOne(T MyItem)
        {

            Context.Set<T>().Update(MyItem);
            Context.SaveChanges();
        }

        public void DeleteOne(T MyItem)
        {

            Context.Set<T>().Remove(MyItem);
            Context.SaveChanges();
        }

        public void AddList(IEnumerable<T> MyList)
        {
            Context.Set<T>().AddRange(MyList);
            Context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> MyList)
        {
            Context.Set<T>().UpdateRange(MyList);
            Context.SaveChanges();
        }

        public void DeleteList(IEnumerable<T> MyList)
        {
            Context.Set<T>().RemoveRange(MyList);
            Context.SaveChanges();
        }
    }
}
