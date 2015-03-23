using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
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
                        "<name></name>" +
                        "<address></address>" +
                        "<product></product>" +
                        "<quantity></quantity>" +
                        "<supplier></supplier>" +
                    "</filds>"
            };

            var records = new List<RecordDto>();
            
            records.Add(new RecordDto
            {
                Code = "123",
                Name = "AnyName"
            });

            records.Add(new RecordDto
            {
                Code = "456",
                Name = "MyName"
            });

            int Counter = 1;
            var xElement = XElement.Load(new MemoryStream(Encoding.UTF8.GetBytes(directory.XmlStructere)));

            foreach (var record in records)
            {
                record.Contents = new DynamicXml(xElement); //TODO change with  parsing string to Xelement

                record.Contents.name = "Olga" + Counter;

                record.Contents.quantity = Counter;

                Console.WriteLine("{0} : {1}", record.Contents.name, record.Contents.quantity);
               
                Counter++;
            }

            

            var Records = new List<Record>();
            
            foreach (var record in records)
            {
                    Records.Add(new Record
                    {
                        Name = record.Name,

                        Code = record.Code,

                        Contents = JsonConvert.SerializeObject(record.Contents)

                    });


            }

            var _records = new List<RecordDto>();

            Records.ForEach(x => _records.Add(new RecordDto
            {
                Name = x.Name,
                Code = x.Code,
                Contents = JsonConvert.DeserializeObject<DynamicXml>(x.Contents)
            }));



            foreach (RecordDto record in _records)
            {
                Console.WriteLine();
                Console.WriteLine("{0} ::: {1}",  record.Contents.name, record.Contents.quantity);
                Console.WriteLine();
            }

            Console.ReadKey();

        }
    }
}
