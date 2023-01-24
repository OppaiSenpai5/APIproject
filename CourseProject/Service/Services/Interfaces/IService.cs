using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
