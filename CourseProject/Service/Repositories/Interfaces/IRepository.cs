namespace Service.Repositories.Interfaces
{
    using Models.Entities;

    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();
        T Get(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool ExistsById(Guid id);
    }
}
