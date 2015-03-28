using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using Noris.Dao.Api;
using Noris.Data.Entity;

namespace Noris.Dao.Dao
{
    /// <summary>
    /// Базовый класс для служб доступа к данным (репозиториям), обеспечивающий абстракцию
    /// всех основных операций над данными: создание, удаление, изменение, чтение.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности модели данных</typeparam>
    /// <typeparam name="TConnection">Тип класса контекста доступа к данным</typeparam>
    public class BaseDao<TEntity> : IDao<TEntity>
        where TEntity : BaseEntity
    {
        [Dependency]
        public DbConnection DbConnection { get; set; }

        [Dependency]
        public IIdentifierProvider IdentifierProvider { get; set; }

        /// <summary>
        /// Cached big valume data for prevent repeat loading from db
        /// This cache refreshed with adding or modified data
        /// </summary>
        protected IList<TEntity> Cache;

        public void CacheClear()
        {
            Cache.Clear();
            Cache = null;
        }

        public virtual TEntity Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entity.Id = IdentifierProvider.NewIdentifier();
            entity.CreatedDate = entity.ModifiedDate = DateTime.UtcNow;
            //entity.CreatedById = entity.ModifiedById = 1;// Convert.ToInt32(User.Identity.Name); TODO Допилить
            var result = DbConnection.GetSet<TEntity>().Add(entity);
            DbConnection.SaveChanges();

            if (Cache != null)
            {
                Cache.Add(result);
            }

            return result;
        }

        /// <summary> TODO need optimizate
        /// </summary>
        public virtual IList<TEntity> Add(IList<TEntity> entityList)
        {
            if (entityList == null)
                return null;

            var result = new List<TEntity>();
            var identifiers = IdentifierProvider.NewIdentifiers(entityList.Count).GetEnumerator();
            foreach (var entity in entityList)
            {
                identifiers.MoveNext();
                entity.Id = identifiers.Current;
                entity.CreatedDate = entity.ModifiedDate = DateTime.UtcNow;
                //entity.CreatedById = entity.ModifiedById = 1; // Convert.ToInt32(User.Identity.Name); TODO Допилить
                result.Add(DbConnection.GetSet<TEntity>().Add(entity));
            }

            DbConnection.SaveChanges();

            if (Cache != null)
            {
                result.ForEach(x => Cache.Add(x));
            }

            return result;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            // TODO не следует методу Update передавать управление на Add, это
            // не очевидно из смысла метода, лучше вернуть соответствующее исключение!!!
            // Если такое поведение необходимо, то лучше создать дополнительный метод AddOrUpdate

            // это заместо оператора ==, т.к. его нельзя использовать для сравнения значений generic типов
            if (EqualityComparer<Guid>.Default.Equals(entity.Id, default(Guid)))
            {
                return Add(entity);
            }

            entity.ModifiedDate = DateTime.UtcNow;
            //entity.ModifiedById = 1;// Convert.ToInt32(User.Identity.Name); TODO Допилить

            var entry = DbConnection.Entry(entity);
            //var original = DbConnection.GetSet<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id.Equals(entity.Id));
            entry.Property(o => o.Id).IsModified = false;
            entry.State = EntityState.Modified;
            entry.Property(e => e.CreatedDate).IsModified = false;
            var result = entry.Entity;
            DbConnection.SaveChanges();
            return result;
        }

        /// <summary>
        /// TODO modified method for prevent removing object
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbConnection.GetSet<TEntity>().Remove(entity);
            //var type = entity.GetType().BaseType;
            DbConnection.SaveChanges();
        }

        public virtual void Delete(Guid id)
        {
            Delete(Get(id));
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return GetAll(new DaoParametrs {IsWithDeleted = false, IsNeedCached = false});
        }

        public virtual IQueryable<TEntity> GetAll(DaoParametrs parameters)
        {
            if (parameters == null) throw new ArgumentNullException("parameters");
            IQueryable<TEntity> query;

            if (parameters.IsNeedCached) //Требуется кеширование
            {
                if (Cache == null) //Если ранеше данные в кеш не наполнялись
                {
                    Cache = DbConnection.GetSet<TEntity>().AsQueryable().ToList(); //Наполнить кеш
                }

                query = Cache.AsQueryable();
            }
            else
            {
                query = DbConnection.GetSet<TEntity>().AsQueryable();
            }

            if (!parameters.IsWithDeleted)
            {
                query = query.Where(x => x.DeletedDate != null);
            }

            return query;
        }

        public virtual TEntity Get(Guid id)
        {
            return DbConnection.GetSet<TEntity>().Find(id);
        }

        public virtual void Dispose()
        {
            DbConnection.Dispose();
        }

        public virtual void SaveChanges()
        {
            DbConnection.SaveChanges();
        }

    }

}
