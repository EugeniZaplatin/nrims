using System;

namespace Noris.Data.Entity
    
{
    /// <summary>
    /// Base class for all entities in solution
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

    }
}
