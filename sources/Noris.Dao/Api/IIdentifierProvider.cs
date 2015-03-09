using System;
using System.Collections.Generic;

namespace Noris.Dao.Api
{
    /// <summary>
    /// Интерфейс провайдера идентификаторов сущностей.
    /// При реализации выполняет создание уникального идентификатора, который
    /// гарантированно не повторяется при генерации одним и тем же провайдером.
    /// </summary>
    public interface IIdentifierProvider
    {
        /// <summary>
        /// Создаёт новый идентификатор
        /// </summary>
        /// <returns>Идентификатор</returns>
        Guid NewIdentifier();

        /// <summary>
        /// Создаёт набор из указанного количества идентификаторов
        /// </summary>
        /// <returns>Набор идентификаторов</returns>
        IEnumerable<Guid> NewIdentifiers(int count);
    }
}
