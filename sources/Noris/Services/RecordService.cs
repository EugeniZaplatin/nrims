using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noris.Api.Services;
using Noris.Dao.Repositories;
using Noris.Data.Dpo;
using Noris.Data.Entity;
using Noris.Services.Bl;
using Noris.Unity.Attributes;

namespace Noris.Services
{
    [Service(typeof(IRecordService))]
    public class RecordService : BaseService<Record, RecordDpo, RecordDao>, IRecordService
    {
        protected override IQueryable<Record> _doFiltration(IQueryable<Record> query, object filters)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<Record> _doSorting(IQueryable<Record> query, IList<SortingInfo> sorters)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<Record> _getList()
        {
            throw new NotImplementedException();
        }

        
        public new Record Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Record Create(Data.Dto.RecordDto dto)
        {
            throw new NotImplementedException();
        }

        public Record Update(Record entity, Data.Dto.RecordDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
