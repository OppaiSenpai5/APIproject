using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Service.Interfaces
{
    public interface IBaseService<T>
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
