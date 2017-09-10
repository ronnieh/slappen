using System.Collections.Generic;

namespace SLapp.SLApi.Models
{
    public class Line{
        public int LineNumber { get; set; }
        public string LineDesignation { get; set; }
        public string TransportName { get; set; }
        public string TransportMode { get; set; }
        
        public List<JourneyPoint> JourneyPoints { get; set; }
    }
}