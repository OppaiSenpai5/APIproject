using Models.Entities;

namespace Service.Services.Interfaces
{
    public interface IService<T> where T : Entity
    {
        T GetById(Guid id);
        IQueryable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
