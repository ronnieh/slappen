using System;

namespace SLapp.SLApi.Models
{
    public class StopPoint{
        public int StopPointNumber { get; set; }
        public string StopPointName { get; set; }
        public string StopAreaNumber { get; set; }
        public string LocationNorthingCoordinate { get; set; }
        public string LocationEastingCoordinate { get; set; }
        public string ZoneShortName { get; set; }
        public string StopAreaTypeCode { get; set; }
        public string ExistsFromDate { get; set; }
    }
}