using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
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
                        "<address>Весення</address>" +
                        "<product></product>" +
                        "<quantity></quantity>" +
                        "<supplier></supplier>" +
                    "</filds>"
            };
            string _xml = 
                "<root>" +
                    "<column name=\"FirstName\">Miron</column>" +
                    "<column name=\"LastName\">Abramson</column>" +
                    "<column name=\"Blog\">www.blog.mironabramson.com</column>" +
                "</root>";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(_xml);

            dynamic newObject = DynamicObjectBuilder.CreateOurNewObject(xmlDoc, typeof(RecordDtoExample));

            newObject.FirstName = "Евгений";
            newObject.LastName = "Заплатин";
            newObject.Name = "Программист";
            newObject.Code = "234";

            Console.WriteLine(newObject.FirstName);
            Console.WriteLine(newObject.LastName);
            Console.WriteLine(newObject.Blog);
            Console.WriteLine(newObject.Name);
            Console.WriteLine(newObject.Code);

            
            var str = JsonConvert.SerializeObject(newObject);
            
            Console.WriteLine(str);

            var _newObject = JsonConvert.DeserializeObject(str, newObject.GetType());

            Console.WriteLine(_newObject.FirstName);
            Console.WriteLine(_newObject.LastName);
            Console.WriteLine(_newObject.Blog);

             str = JsonConvert.SerializeObject(newObject);

            Console.WriteLine(str);

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
