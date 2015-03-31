using System;
using System.Collections.Generic;
using System.ServiceModel;
using Noris.WcfService.Data;

namespace Noris.Wcf
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract]
    public interface IWcfService
    {

        /// <summary>
        /// Return all records of directory categories
        /// </summary>
        /// <returns>list categories</returns>
        [OperationContract]
        IList<CategorySto> GetCategories();

        /// <summary>
        /// Return all records of directory
        /// </summary>
        /// <returns>list directories</returns>
        [OperationContract]
        IList<DiectorySto> GetDirectories();

        /// <summary>
        /// Return all records of directory from specified category
        /// </summary>
        /// <param name="categoryId">Directory identifier</param>
        /// <returns>list pairs id and name of directories</returns>
        [OperationContract(Name = "GetDirectoriesByCategory")]
        IList<DiectorySto> GetDirectories(Guid categoryId);
        
        /// <summary>
        /// Return all records of directory
        /// </summary>
        /// <param name="id">Directory identifier</param>
        /// <returns></returns>
        [OperationContract]
        IList<RecordSto> GetDirectory(Guid id);

        /// <summary>
        /// Return all records of directory
        /// </summary>
        /// <param name="version">poin last update version of directory</param>
        /// /// <param name="id">directory identifier</param>
        /// <returns></returns>
        [OperationContract]
        IList<RecordSto> GetRecords(Guid id, string version);

        /// <summary>
        /// Return metadata of directory
        /// </summary>
        /// <param name="id">Directory identifier</param>
        /// <returns>Description direstory structure</returns>
        [OperationContract]
        string GetDirectoryMetadata(Guid id);
       
    }

   
   
}
