using System;
using Noris.Data.Api;

namespace Noris.Data.Entity
    
{
    /// <summary>
    /// Base class for all entities in solution
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Дата создания записи в UTC времени. Устанавливается единожды при создании и остаётся неизменной
        /// в течение всего срока жизни сущности
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Инициатор создания записи
        /// </summary>
        public IInitiator CreatedBy { get; set; }

        /// <summary>
        /// Дата последнего изменения записи в UTC времени. Отражает только существенные изменения
        /// в данных записи, а также в её связях и зависимых записях
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Инициатор последнего изменения записи
        /// </summary>
        public IInitiator ModifiedBy { get; set; }

        /// <summary>
        /// Дата удаления сущности в UTC времени. Сущность не удаляется из системы, но лишь помечается как удалённая после
        /// определённой даты. Запись считается удалённой, если дата удаления задана и меньше либо равна дате на текущий момент
        /// </summary>
        public DateTime? DeletedDate { get; set; }

    }
}
