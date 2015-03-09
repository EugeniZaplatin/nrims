namespace Noris.Dao.Dao
{
    /// <summary>
    /// Same parametrs what charaсterize dao method execution
    /// </summary>
    public class DaoParametrs
    {
        /// <summary>
        /// Требуется показывать записи, отмеченные как  удаленные
        /// </summary>
        public bool IsWithDeleted { get; set; }

        /// <summary>
        /// Необходимо кешировать загруженные данные в репозиторий для ускорения выполнения операций с данными
        /// </summary>
        public bool IsNeedCached { get; set; }

    }
}
