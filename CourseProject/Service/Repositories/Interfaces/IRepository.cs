using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
