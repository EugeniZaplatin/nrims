using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using Noris.Data;
using Noris.Data.Dto;
using Noris.Data.Entity;
using Noris.Data.Sto;
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

                record.Contents.product = "Apple" + Counter;

                record.Contents.quantity = Counter;

                Console.WriteLine("{0} : {1}", record.Contents.product, record.Contents.quantity);
               
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

            var ExportRecords = new List<DynamicSto>();
            
            
            
            foreach (RecordDto record in _records)
            {
                dynamic dyn = new DynamicSto(xElement)
                {
                     name = record.Name,
                     code = record.Code,
                     version = ""
                };

                ExportRecords.Add(dyn);

                Console.WriteLine();
                Console.WriteLine("{0} ::: {1}",  record.Contents.product, record.Contents.quantity);
                Console.WriteLine(JsonConvert.SerializeObject(dyn));
            }

            dynamic d = new {pico = "erwer", memo = "ok"};

            Console.WriteLine(JsonConvert.SerializeObject(d));

            Console.ReadKey();

        }
    }
}
