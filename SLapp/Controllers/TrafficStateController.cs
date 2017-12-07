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
    public class TrafficStateController : Controller
    {
        private readonly TrafficStateManager _trafficStateManager;
        
        public TrafficStateController(TrafficStateManager trafficStateManager){
            _trafficStateManager = trafficStateManager;
        }
        
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var test = await _trafficStateManager.GetTrafficState();
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
