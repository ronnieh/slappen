using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SLapp.SLApi;
using SLapp.SLApi.Models;

namespace TrafikApi.Controllers
{
    [Route("api/[controller]")]
    public class RealTimeController : Controller
    {
        private readonly RealTimeManager _realTimeManager;
        
        public RealTimeController(RealTimeManager realTimeManager){
            _realTimeManager = realTimeManager;
        }
        
        [HttpGet]
        public async Task<JsonResult> Get(string siteId)
        {
            var test = await _realTimeManager.GetRealTimeInfoAsync(siteId);
            return Json(test);
        }
        // GET: api/values
        /*[HttpGet("{transportMode}")]
        public JsonResult Get(string transportMode)
        {
            var lines = _linesManager.GetLines(transportMode).Result;
            return Json(lines);
        }*/

    }
}
