using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noris.Data.Constants;
using Noris.Services.Api;
using Noris.Unity.Attributes;

namespace Noris.Services.Bl
{
    [Service(typeof(IImportService))]
    public class ImportService : IImportService
    {
        public ImportResults Import(string file, Data.Entity.Directory directory)
        {
            var result = ImportResults.BadStructure;

            //Load file and determine its foremat by extention
            var _file = new FileInfo(file);

            string extention = _file.Extension;

            //Depending on format invoke handler
            if (extention.ToLower().Equals("xml"))
            {
                result = _importFromXml(_file);
            }
            else if (extention.ToLower().Equals("dbf"))
            {
                result = _importFromDbf(_file);
            }
            else
            {
                //Exeption
            }

            return result;
        }

        private ImportResults _importFromDbf(FileInfo file)
        {
            throw new NotImplementedException();
        }

        private ImportResults _importFromXml(FileInfo file)
        {
            throw new NotImplementedException();
        }
    }
}
