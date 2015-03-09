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

        IList<TEntity> Finalise(IQueryable<TEntity> query);

        void CacheClear();

        /// <summary>
        /// Переопределяется при необходимости подгрузки свойств из внешних контекстов
        /// </summary>
        TEntity Finalise(TEntity entity);

        /// <summary>Позволяет прогружать отдельные свойства с типами внешних
        /// по отношению сущностей, что в целом ускоряет процесс финализации
        /// </summary>
        /// <param name="id">идентификатор свойства, наприер PersonId в Patient</param>
        /// <returns></returns>        
        TEntity Finalise(Guid id);
    }
}
