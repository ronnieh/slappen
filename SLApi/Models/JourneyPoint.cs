using System;

namespace SLapp.SLApi.Models
{
    public class JourneyPoint{
        public int LineNumber { get; set; }
        public string DirectionCode { get; set; }
        public int JourneyPatternPointNumber { get; set; }
        public string ExistsFromDate { get; set; }
        
        public StopPoint StopPoint { get; set; }
    }
}