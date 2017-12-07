using System;
using System.Collections.Generic;

namespace SLapp.SLApi.ResponseModels
{
    public class SiteInformationResponseObject
    {
        public string Name { get; set; }
        public string SiteId { get; set; }
        public string Type { get; set; }
        public string X { get; set; }
        public string Y { get; set; }

    }


    public class SiteInformationResponse
    {
        public int StatusCode { get; set; }
        public object Message { get; set; }
        public int ExecutionTime { get; set; }
        public List<SiteInformationResponseObject> ResponseData { get; set; }
    }
}
