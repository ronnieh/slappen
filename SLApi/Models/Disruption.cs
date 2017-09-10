using System;

namespace SLapp.SLApi.Models
{
    public class Disruption{
        public string Description { get; set; }
        public string Heading { get; set; }
        public bool IsMainNews { get; set; }
        public DateTime ReportedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string TransportMode { get; set; }
        public string LineNumber { get; set; }
    }
}