using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Noris.Data.Constants
{
    /// <summary>
    /// Results of import directory operation
    /// </summary>
    public enum ImportResults
    {
        [Description("Data loading is suaccessfully" )]
        Sucsessfully  = 1,
        
        [Description("Incorrect data structure for load to directory")]
        InvalidStructure = 2,

        [Description("Unknown data format")]
        UnknownFormat = 3


    }
}
