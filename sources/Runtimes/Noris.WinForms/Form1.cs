using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Noris.Data.Dto;
using Noris.Services.Utils;
using Noris.Utils;

namespace Noris.WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string _xml =
               "<root>" +
                   "<column name=\"FirstName\"></column>" +
                   "<column name=\"LastName\"></column>" +
                   "<column name=\"Blog\"></column>" +
               "</root>";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(_xml);

            //prepere any data for binding to DataGridView
            var list = new List<dynamic>();

            for (int i = 0; i <= 10; i++)
            {
                dynamic dyn =  DynamicObjectBuilder.CreateOurNewObject(xmlDoc, typeof (RecordDtoExample));


                dyn.FirstName = "Eugeni" + i.ToString();

                dyn.LastName = "Zapalatin" + i.ToString();

                dyn.Blog = String.Format("www.{0}.ru", dyn.LastName);

                dyn.Code = i.ToString();

                dyn.Name = "Data" + i.ToString();

                list.Add(dyn);


            }

            var listEnumer = (IEnumerable<dynamic>)list;

            //DataTable table = listEnumer.ToDataTable();

            try
            {
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
