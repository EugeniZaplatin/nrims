using System;
using System.Collections.Generic;
using System.Linq;
using Noris.Dao.Dao;
using Noris.Data.Entity;

namespace Noris.Dao.Api
{
    public interface IDao<TEntity> : IDisposable
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(DaoParametrs parameters);

        TEntity Add(TEntity entity);

        IList<TEntity> Add(IList<TEntity> entityList);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(Guid id);

        TEntity Get(Guid id);

        void SaveChanges();

        void CacheClear();

       
    }
}
