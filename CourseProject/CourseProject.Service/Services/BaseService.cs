using CourseProject.Data;
using CourseProject.Data.Entities;
using CourseProject.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public BaseService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public virtual void Create(T entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();

        }

        public virtual void Delete(T entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }

        public virtual T Get(Guid id)
        {
            return this.dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.dbSet;
        }

        public virtual void Update(T entity)
        {
            this.dbSet.Update(entity);
            this.dbContext.SaveChanges();
        }
    }
}
