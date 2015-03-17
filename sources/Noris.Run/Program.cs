﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Noris.Data.Entity;

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
                    "<content > <customer><name>Wile E Coyote</name><address>The Desert</address></customer> " +
                    "<orderItem><product>Rocket Powered Rollerskates</product>" +
                    "<quantity>1</quantity><supplier>Acme Inc</supplier></orderItem></content>"
            };
        }
    }
}
