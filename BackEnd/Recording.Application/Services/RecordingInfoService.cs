using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Recording.Application.IServices;
using Recording.Models.ResponseModels.RecordingInfo;
using Recording.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recording.Application.Services
{
    public class RecordingInfoService : BaseService, IRecordingInfoService
    {
        public RecordingInfoService(IOptionsSnapshot<AppSettings> appSettingsAccessor) : base(appSettingsAccessor)
        {
        }
        public async Task<List<RecordingInfoListResponse>> GetRecordingInfoList(RecordingInfoListRequest request)
        {
            Console.WriteLine("success");
            var result = new List<RecordingInfoListResponse>();
            await DbContext.recording_infos.Where(r => !r.Is_Deleted).ToListAsync();

            return result;
        }
    }
}
