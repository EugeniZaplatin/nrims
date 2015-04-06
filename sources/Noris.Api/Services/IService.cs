using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noris.Data.Dto;
using Noris.Data.Entity;

namespace Noris.Api.Services
{
    public class AccessInfo
    {
        public IList<string> Permissions { get; set; }

        public long CurrentUserId { get; set; }
    }

    public class SortingInfo
    {
        public string Field { get; set; }
        public string Direction { get; set; }
    }

    public class FilteringInfo
    {
        public string Field { get; set; }
        public object Value { get; set; }
        public string Operator { get; set; }
    }

    public interface IGetListSupport<out TEntity>
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> Get(object filters, IList<SortingInfo> sorters);
    }

    public interface IGetSingleSupport<out TEntity>
        where TEntity : BaseEntity
    {
        TEntity Get(Guid id);
    }


    /// <summary>
    /// В контекст добавляется новая инстанция но основе импортированных данных
    /// </summary>
    /// <typeparam name="D">структура dto содержащая импортированные данные</typeparam>
    public interface ICreateSupport<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        TEntity Create(TDto dto);
    }

    /// <summary> Обновляется уже сущестующая инстанция на основе импортированных данных
    /// Каждая сущность реализует эту процедуру согласно собственной бизнес логике
    /// </summary>
    /// <typeparam name="TDto">структура dto содержащая импортированные данные</typeparam>
    public interface IUpdateSupport<TEntity, in TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        TEntity Update(TEntity entity, TDto dto);
    }

    public interface IDeleteSupport
 
    {
        void Delete(Guid id);
    }

    public interface IUpdateListSupport<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto

    {
        IList<TEntity> UpdateList(IList<TDto> values);
    }
}
