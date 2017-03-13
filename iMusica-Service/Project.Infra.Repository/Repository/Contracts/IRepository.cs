using System;
using System.Collections.Generic;

namespace Project.Infra.Repository.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        IList<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
