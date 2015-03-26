using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using Noris.Dao;
using Noris.Dao.Migrations;
using Noris.Data.Entity;

namespace Urish.Diagnostic.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentCatalog = Path.GetDirectoryName(typeof(Program).Assembly.Location.TrimEnd('\\', '/'));
            AppDomain.CurrentDomain.SetData("DataDirectory", currentCatalog);
            Database.SetInitializer(new CreateDatabaseIfNotExists<DbConnection>());
            try
            {
                new DbMigrator(new Configuration()).Update();

                using (var connection = new DbConnection("DefaultConnection"))
                {
                    var records = Enumerable.Range(1, 10000)
                        .Select(o =>
                        {
                            var record = new Record
                            {
                                Id = Guid.NewGuid(),
                                Code = o.ToString(),
                                Contents = "AAAA",
                                CreatedDate = DateTime.Now,
                                ModifiedDate = DateTime.Now
                            };
                            Console.WriteLine(o);
                            return record;
                        }).ToArray();
                    connection.Records.AddRange(records);
                    connection.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
