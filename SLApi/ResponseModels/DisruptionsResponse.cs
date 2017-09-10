using System.Collections.Generic;

namespace SLapp.SLApi.ResponseModels{

    public class DisruptionResponseItem
    {
        public string Created { get; set; }
        public bool MainNews { get; set; }
        public int SortOrder { get; set; }
        public string Header { get; set; }
        public string Details { get; set; }
        public string Scope { get; set; }
        public object DevCaseGid { get; set; }
        public int DevMessageVersionNumber { get; set; }
        public string ScopeElements { get; set; }
        public string FromDateTime { get; set; }
        public string UpToDateTime { get; set; }
        public string Updated { get; set; }
        public string LineNumber { get; set; }
    }

    public class DisruptionsResponse
    {
        public int StatusCode { get; set; }
        public object Message { get; set; }
        public int ExecutionTime { get; set; }
        public List<DisruptionResponseItem> ResponseData { get; set; }
    }
}