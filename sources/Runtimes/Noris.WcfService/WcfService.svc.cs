using System;


namespace Noris.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WcfService.svc or WcfService.svc.cs at the Solution Explorer and start debugging.
    public class WcfService : IWcfService
    {

        public System.Collections.Generic.IList<Noris.WcfService.Data.CategorySto> GetCategories()
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IList<Noris.WcfService.Data.DiectorySto> GetDirectories()
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IList<Noris.WcfService.Data.DiectorySto> GetDirectories(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IList<Noris.WcfService.Data.RecordSto> GetDirectory(Guid id)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IList<Noris.WcfService.Data.RecordSto> GetRecords(Guid id, string version)
        {
            throw new NotImplementedException();
        }

        public string GetDirectoryMetadata(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
