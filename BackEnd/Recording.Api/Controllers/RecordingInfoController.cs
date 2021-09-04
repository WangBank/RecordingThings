using Microsoft.AspNetCore.Mvc;
using Recording.Application.IServices;
using Recording.Models.ResponseModels.RecordingInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recording.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordingInfoController : ControllerBase
    {
        private IRecordingInfoService _recordingInfoService;
        public RecordingInfoController(IRecordingInfoService RecordingInfoService)
        {
            _recordingInfoService = RecordingInfoService;
        }
        [HttpGet]
        public async Task<List<RecordingInfoListResponse>> List([FromQuery]RecordingInfoListRequest request)
        {
            return await _recordingInfoService.GetRecordingInfoList(request);
        }
    }
}
