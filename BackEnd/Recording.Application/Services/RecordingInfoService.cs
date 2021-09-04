using Microsoft.EntityFrameworkCore;
using Recording.Application.IServices;
using Recording.Models.ResponseModels.RecordingInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recording.Application.Services
{
    public class RecordingInfoService : BaseService, IRecordingInfoService
    {
        public async Task<List<RecordingInfoListResponse>> GetRecordingInfoList(RecordingInfoListRequest request)
        {
            Console.WriteLine("success");
            var result = new List<RecordingInfoListResponse>();
            await DbContext.recording_infos.Where(r => !r.Is_Deleted).ToListAsync();

            return result;
        }
    }
}
