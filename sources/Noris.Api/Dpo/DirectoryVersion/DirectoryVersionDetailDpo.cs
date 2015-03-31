namespace Noris.Data.Dpo
{
    /// <summary>
    /// Version of directory. Each record should has link to any directory version
    /// </summary>
    public class DirectoryVersionDetailDpo : DirectoryVersionDpo
    {        
        public string Description { get; set; }
        
        public DirectoryDpo DirectoryDpo { get; set; }

    }
}
