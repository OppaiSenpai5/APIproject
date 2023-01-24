using Service.Exceptions;
using Models.Entities;
using Service.Repositories;
using Service.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class Service<TEntity, TRepository> : IService<TEntity>
        where TEntity : Entity
        where TRepository : IRepository<TEntity>
    {
        protected readonly TRepository repository;

        public Service(TRepository repository) =>
            this.repository = repository;

        public virtual void Create(TEntity entity)
        {
            try
            {
                this.repository.Create(entity);
            }
            catch
            {
                throw new BadRequestException();
            }
        }

        public virtual void Delete(Guid id)
        {
            try
            {
                this.repository.Delete(GetById(id));
            }
            catch
            {
                throw new BadRequestException();
            }
        }

        public virtual IQueryable<TEntity> GetAll() =>
            this.repository.GetAll();

        public virtual TEntity GetById(Guid id)
        {
            if (this.repository.Get(id) is TEntity entity)
            {
                return entity;
            }

            throw new NotFoundException();
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                this.repository.Update(entity);
            }
            catch
            {
                throw new BadRequestException();
            }
        }
    }
}
