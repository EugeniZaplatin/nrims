using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.Unity;
using Noris.Dao.Api;
using Noris.Data.Entity;
using Noris.Services.Attributes;

namespace Noris.Services.Bl
{
    /// <summary>
    /// Specified fild in listing forms and deriction of sorting data
    /// </summary>
    public class SortingInfo
    {
        public string Field { get; set; }
        public string Direction { get; set; }
    }

    /// <summary>
    /// Base class for all bisness entities which interact with database
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDetail">Dto object for UI forms</typeparam>
    /// <typeparam name="TRepo">Dao repository</typeparam>
    public abstract class BaseService<TEntity, TDetail, TRepo>
        where TEntity : BaseEntity
        where TRepo : IDao<TEntity>
    {
        [Dependency]
        public TRepo Repository { get; set; }

        public TDetail Get(Guid id)
        {
            var entity = Repository.Get(id);
            return Mapper.Map<TDetail>(entity);
        }

        public virtual IQueryable<TEntity> Get(object filters, IList<SortingInfo> sorters)
        {
            var result = _getList();
            result = _doFiltration(result, filters);
            if (sorters != null)
            {
                result = _doSorting(result, sorters);
            }

            return result;
        }
        

        [Transactional]
        public virtual TDetail Create(TDetail detailDto)
        {
            var entity = Mapper.Map<TEntity>(detailDto);
            entity = Repository.Add(entity);

            return Mapper.Map<TDetail>(entity);
        }

        [Transactional]
        public virtual TDetail Update(Guid id, TDetail detailDto)
        {
            var entity = Repository.Get(id);

            entity = Mapper.Map(detailDto, entity);
            entity = Repository.Update(entity);

            return Mapper.Map<TDetail>(entity);
        }

        [Transactional]
        public virtual void Delete(Guid id)
        {
            var entity = Repository.Get(id);
            if (entity == null) return;

            //Cледует не удалять а отмечать как удаленный. Это важно, 
            //т.к. сведения об удалении объектов нужно будет передавать на публичные сайты
            entity.DeletedDate = DateTime.Now;
            Repository.Update(entity);
        }


        protected abstract IQueryable<TEntity> _doFiltration(IQueryable<TEntity> query, object filters);

        protected abstract IQueryable<TEntity> _doSorting(IQueryable<TEntity> query, IList<SortingInfo> sorters);

        protected abstract IQueryable<TEntity> _getList();

        protected virtual string defaultSortField
        {
            get
            {
                return "id";
            }
        }
    }
}
