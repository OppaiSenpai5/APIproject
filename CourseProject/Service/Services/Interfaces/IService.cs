namespace Service.Services.Interfaces
{
    using Models.Entities;

    public interface IService<T> where T : Entity
    {
        T GetById(Guid id);
        IQueryable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
