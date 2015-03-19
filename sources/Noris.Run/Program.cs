using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Xml.Linq;
using Noris.Data.Dto;
using Noris.Data.Entity;
using Noris.Services.Utils;
using Directory = Noris.Data.Entity.Directory;

namespace Urish.Diagnostic.Run
{
    class Program
    {
        static void Main(string[] args)
        {

            var directory = new Directory
            {
                Name = "Test directory",
                BriefDescription = "Brife description",
                Category = new DirectoryCategory
                {
                    Name = "Medical directories"
                },
                XmlStructere =
                    "<filds>" +
                        "<prop>" +
                            "<name>Eugeny</name>" +
                            "<address>Vesennay</address>" +
                            "<product>Gold</product>" +
                            "<quantity>3</quantity>" +
                            "<supplier>Any</supplier>" +
                        "</prop>" +
                    "</filds>"
            };
           
            var record = new RecordDto
            {
                Code = "123",
                Name = "AnyName"
            };

            var xElement = XElement.Load(new MemoryStream(Encoding.UTF8.GetBytes(directory.XmlStructere)));

            record.Contents = new DynamicClassBuilder(xElement); //TODO change with  parsing string to Xelement

           Console.WriteLine("{0} : {1}", record.Contents.prop.name, record.Contents.prop.quantity);

            record.Contents.prop.name = "Olga";

            Console.WriteLine("{0} : {1}", record.Contents.prop.name, record.Contents.prop.quantity);

            Console.ReadKey();

        }
    }
}
