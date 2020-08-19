using Shop.Core.Contracts;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAcessSQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext dataContext;
        internal DbSet<T> dbSet;

        public SQLRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
            this.dbSet = dataContext.Set<T>();
        }

        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Commit()
        {
            this.dataContext.SaveChanges(); 
        }

        public void Delete(string Id)
        {
            var t = this.Find(Id);

            if(dataContext.Entry(t).State == EntityState.Detached)
            {
                this.dbSet.Attach(t);
            }

            this.dbSet.Remove(t);
        }

        public T Find(string Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T t)
        {
            this.dbSet.Add(t);
        }

        public void Update(T t)
        {
            this.dbSet.Attach(t);
            this.dataContext.Entry(t).State = EntityState.Modified;
        }
    }
}
