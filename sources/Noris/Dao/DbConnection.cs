﻿using System.Data.Entity;
using Noris.Core.Dao.Mapping;
using Noris.Unity.Attributes;
using Noris.Data.Entity;


namespace Noris.Dao
{
    /// <summary>
    /// Main database context for solution
    /// </summary>
    [Configuration]
    public class DbConnection : DbContext
    {
        public DbConnection():base("DefaultConnection")
        {
            
        }
        public DbConnection(string connectionString):base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DirectoryMap());
            modelBuilder.Configurations.Add(new DirectoryVersionMap());
            modelBuilder.Configurations.Add(new DirectoryCategoryMap());
            modelBuilder.Configurations.Add(new RecordMap()); 
        }

        public virtual DbSet<TEntity> GetSet<TEntity>()
            where TEntity : BaseEntity
        {
            return this.Set<TEntity>();
        }

        public DbSet<Record> Records { get; set; }
    }

}
