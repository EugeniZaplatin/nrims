using System;
using System.IO;
using Noris.Data.Entity;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Noris.Dao;
using Noris.Dao.Migrations;
using Noris.RunTest;


namespace Urish.Diagnostic.Run
{
    class Program
    {
        private static void Main(string[] args)
        {
            TestWithDynamicType.CreateDynamic();

            TestLocalDb.WorkWithLocalDb();
        }
    }
}
