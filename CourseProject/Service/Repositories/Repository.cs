using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Persistence;
using Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext context;
        protected readonly DbSet<T> dbSet;

        public Repository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            this.dbSet.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            this.dbSet.Remove(entity);
            Save();
        }

        public T Get(Guid id) => this.dbSet.Find(id);

        public IEnumerable<T> GetAll() => this.dbSet.ToList();

        public void Update(T entity)
        {
            this.dbSet.Update(entity);
            Save();
        }

        protected void Save() => this.context.SaveChanges();
    }
}
