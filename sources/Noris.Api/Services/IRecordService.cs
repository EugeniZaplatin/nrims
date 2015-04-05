
using Noris.Data.Dto;
using Noris.Data.Entity;

namespace Noris.Api.Services
{
    public interface IRecordService : IGetListSupport<Record>
                                      , IGetSingleSupport<Record>
                                      , ICreateSupport<Record, RecordDto>
                                      , IUpdateSupport<Record, RecordDto>
    {
    }
}
