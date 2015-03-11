using Noris.Data.Constants;
using Noris.Data.Entity;

namespace Noris.Services.Api
{
    /// <summary>
    /// Declarate methods for import directories from different sources and variose formats
    /// </summary>
    public interface IImportService
    {
        /// <summary>
        /// Importing data from specified file to directory
        /// Directory structure must be beforehand prepared
        /// All properties should be match imported feilds (dbf) or tags (xml)
        /// </summary>
        /// <param name="file">full path to file</param>
        ImportResults Import(string file, Directory directory);
    }
}
