using System.Collections.Generic;

namespace SLapp.SLApi.ResponseModels
{
    public class JourneyPointResult
    {
        public int LineNumber { get; set; }
        public string DirectionCode { get; set; }
        public int JourneyPatternPointNumber { get; set; }
        public string LastModifiedUtcDateTime { get; set; }
        public string ExistsFromDate { get; set; }
    }

    public class JourneyPointResponseData
    {
        public string Version { get; set; }
        public string Type { get; set; }
        public List<JourneyPointResult> Result { get; set; }
    }

    public class JourneyPointRootObject
    {
        public int StatusCode { get; set; }
        public int ExecutionTime { get; set; }
        public JourneyPointResponseData ResponseData { get; set; }
    }
}