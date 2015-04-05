using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using Noris.Dao;
using Noris.Dao.Migrations;
using Noris.Dao.Repositories;
using Noris.Data.Entity;
using Urish.Diagnostic.Run;
using Directory = Noris.Data.Entity.Directory;

namespace Noris.RunTest
{
    public class TestLocalDb
    {
        public static void WorkWithLocalDb()
        {
            var currentCatalog = Path.GetDirectoryName(typeof (Program).Assembly.Location.TrimEnd('\\', '/'));
            AppDomain.CurrentDomain.SetData("DataDirectory", currentCatalog);
            Database.SetInitializer(new CreateDatabaseIfNotExists<DbConnection>());
           
                new DbMigrator(new Configuration()).Update();

                var directoryVersin = new DirectoryVersionDao().Add(new DirectoryVersion()
                {
                    VersionNumber = "1.0.0.0",
                    VersionDate = DateTime.Now,
                    Directory = new DirectoryDao().Add(new Directory()
                    {
                        Name = "First directory",
                        XmlStructure = "",
                        BriefDescription = "",
                        Owner = "",
                        Responser = "",
                        FeedbackEmail = "",
                        Category = new DirectoryCategoryDao().Add( new DirectoryCategory()
                        {
                            Name = "Medicine directories",
                            Parent = null
                        })


                    })
                });



                //using (var connection = new DbConnection("DefaultConnection"))
                //{
                    var records = Enumerable.Range(1, 10000)
                        .Select(o =>
                        {
                            var record = new RecordDao().Add( new Record()
                            {
                                Name = "Medicine",
                                Id = Guid.NewGuid(),
                                Code = o.ToString(),
                                Contents = "AAAA",
                                CreatedDate = DateTime.Now,
                                ModifiedDate = DateTime.Now,
                                Version = directoryVersin
                            });
                            Console.WriteLine(o);
                            return record;
                        }).ToArray();
                    //connection.Records.AddRange(records);
                    //connection.SaveChanges();
               // }
           
        }
    }
}
