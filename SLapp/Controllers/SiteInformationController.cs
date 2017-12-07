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
    public class SiteInformationController : Controller
    {
        private readonly SiteInformationManager _siteInformationManager;
        
        public SiteInformationController(SiteInformationManager siteInformationManager){
            _siteInformationManager = siteInformationManager;
        }
        
        [HttpGet("search")]
        public async Task<JsonResult> Search(string query)
        {
            var test = await _siteInformationManager.SearchSitesAsync(query.Trim());
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
