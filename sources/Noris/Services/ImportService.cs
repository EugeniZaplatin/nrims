using System.IO;
using Noris.Data.Constants;
using Noris.Services.Api;
using Noris.Unity.Attributes;
using Directory = Noris.Data.Entity.Directory;

namespace Noris.Services.Bl
{
    [Service(typeof(IImportService))]
    public class ImportService : IImportService
    {
        private Directory Directory { get; set; }

        public ImportResults Import(string file, Directory directory)
        {
            ImportResults result;

            //Load file and determine its foremat by extention
            var _file = new FileInfo(file);

            string extention = _file.Extension;

            
            Directory = directory;

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
                result = ImportResults.UnknownFormat;
            }

            return result;
        }

        

        private ImportResults _importFromDbf(FileInfo file)
        {
            var result = _validateDbfStructure(file);

            if (result == ImportResults.InvalidStructure)
            {
                return result;
            }

            //Import data from Dbf structure and save in db using Dbf parser


            return result;
        }

        private ImportResults _importFromXml(FileInfo file)
        {
            var result = _validateXmlStructure(file);

            if (result == ImportResults.InvalidStructure)
            {
                return result;
            }

            //Import data from Xml structure and save in db using Xml Parcer


            return result;
        }
        
        /// <summary>
        /// Validate xml data structure correspond to directory structure
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private ImportResults _validateXmlStructure(FileInfo file)
        {
            var result = ImportResults.Sucsessfully;

            //Check data structure of file

            //
            if (true)
            {
                result = ImportResults.InvalidStructure;
            }

            return result;
        }

        /// <summary>
        /// Validate dbf data structure correspond to directory structure
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private ImportResults _validateDbfStructure(FileInfo file)
        {
            var result = ImportResults.Sucsessfully;

            //Check data structure of file

            //
            if (true)
            {
                result = ImportResults.InvalidStructure;
            }

            return result;
        }
    }
}
