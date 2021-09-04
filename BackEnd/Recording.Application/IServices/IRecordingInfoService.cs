using Recording.Models.ResponseModels.RecordingInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recording.Application.IServices
{
    public interface IRecordingInfoService: IScopedDependency
    {
        Task<List<RecordingInfoListResponse>> GetRecordingInfoList(RecordingInfoListRequest request);
    }
}
