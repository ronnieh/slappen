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
    public class LinesController : Controller
    {
        private readonly LinesManager _linesManager;
        
        public LinesController(LinesManager linesManager){
            _linesManager = linesManager;
        }
        
        [HttpGet]
        public async Task<JsonResult> Get(string transportMode = null)
        {
            IEnumerable<Line> lines;

            if(!string.IsNullOrWhiteSpace(transportMode)){
                lines = await _linesManager.GetLines(transportMode);
            }else{
                lines = await _linesManager.GetLines();
            }

            return Json(lines);
        }
        // GET: api/values
        /*[HttpGet("{transportMode}")]
        public JsonResult Get(string transportMode)
        {
            var lines = _linesManager.GetLines(transportMode).Result;
            return Json(lines);
        }*/
        
        [HttpGet("Stops")]
        public JsonResult GetStops()
        {
            var lines = _linesManager.GetAllStopPoints().Result;
            return Json(lines);
        }
        
        [HttpGet("Journeys/{lineNumber}")]
        [HttpGet("Journeys")]
        public JsonResult GetJourneys(int? lineNumber = null)
        {
            var journeyPoints = _linesManager.GetJourneyPoints(lineNumber).Result;
            return Json(journeyPoints);
        }
        
        [HttpGet]
        [Route("TransportModes")]
        public JsonResult GetTransportModes()
        {
            var modes = _linesManager.GetTransportModes().Result;
            return Json(modes);
        }

    }
}
