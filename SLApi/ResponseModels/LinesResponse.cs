using System.Collections.Generic;

namespace SLapp.SLApi.ResponseModels
{
    public class LinesResult
    {
        public int LineNumber { get; set; }
        public string LineDesignation { get; set; }
        public string DefaultTransportMode { get; set; }
        public string DefaultTransportModeCode { get; set; }
        public string LastModifiedUtcDateTime { get; set; }
        public string ExistsFromDate { get; set; }
    }

    public class LinesResponseData
    {
        public string Version { get; set; }
        public string Type { get; set; }
        public List<LinesResult> Result { get; set; }
    }

    public class LinesRootResponse
    {
        public int StatusCode { get; set; }
        public object Message { get; set; }
        public int ExecutionTime { get; set; }
        public LinesResponseData ResponseData { get; set; }
    }
}