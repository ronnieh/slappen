using System.Collections.Generic;

namespace SLapp.SLApi.ResponseModels
{
    public class StopPointResult
    {
        public int StopPointNumber { get; set; }
        public string StopPointName { get; set; }
        public string StopAreaNumber { get; set; }
        public string LocationNorthingCoordinate { get; set; }
        public string LocationEastingCoordinate { get; set; }
        public string ZoneShortName { get; set; }
        public string StopAreaTypeCode { get; set; }
        public string LastModifiedUtcDateTime { get; set; }
        public string ExistsFromDate { get; set; }
    }

    public class StopPointResponseData
    {
        public string Version { get; set; }
        public string Type { get; set; }
        public List<StopPointResult> Result { get; set; }
    }

    public class StopPointRootObject
    {
        public int StatusCode { get; set; }
        public int ExecutionTime { get; set; }
        public StopPointResponseData ResponseData { get; set; }
    }
}