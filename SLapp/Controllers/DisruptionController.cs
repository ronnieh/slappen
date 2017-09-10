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
    public class DisruptionController : Controller
    {
        private readonly DisruptionManager _disruptionManager;
        
        public DisruptionController(DisruptionManager disruptionManager){
            _disruptionManager = disruptionManager;
        }
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            var lines = new List<int>() { 13, 14 };
            var disruptions = _disruptionManager.GetDisruptions(lines);
            
            
            return Json(disruptions);
        }

    }
}
