using System;
using System.Collections.Generic;

namespace SLapp.SLApi.ResponseModels
{

public class Metro
    {
        public string GroupOfLine { get; set; }
        public string DisplayTime { get; set; }
        public string TransportMode { get; set; }
        public string LineNumber { get; set; }
        public string Destination { get; set; }
        public int JourneyDirection { get; set; }
        public string StopAreaName { get; set; }
        public int StopAreaNumber { get; set; }
        public int StopPointNumber { get; set; }
        public string StopPointDesignation { get; set; }
        public DateTime? TimeTabledDateTime { get; set; }
        public DateTime? ExpectedDateTime { get; set; }
        public int JourneyNumber { get; set; }
        public object Deviations { get; set; }
    }

    public class Bus
    {
        public string GroupOfLine { get; set; }
        public string TransportMode { get; set; }
        public string LineNumber { get; set; }
        public string Destination { get; set; }
        public int JourneyDirection { get; set; }
        public string StopAreaName { get; set; }
        public int StopAreaNumber { get; set; }
        public int StopPointNumber { get; set; }
        public string StopPointDesignation { get; set; }
        public DateTime TimeTabledDateTime { get; set; }
        public DateTime ExpectedDateTime { get; set; }
        public string DisplayTime { get; set; }
        public int JourneyNumber { get; set; }
        public object Deviations { get; set; }
    }

    public class Tram
    {
        public string TransportMode { get; set; }
        public string LineNumber { get; set; }
        public string Destination { get; set; }
        public int JourneyDirection { get; set; }
        public string GroupOfLine { get; set; }
        public string StopAreaName { get; set; }
        public int StopAreaNumber { get; set; }
        public int StopPointNumber { get; set; }
        public string StopPointDesignation { get; set; }
        public DateTime TimeTabledDateTime { get; set; }
        public DateTime ExpectedDateTime { get; set; }
        public string DisplayTime { get; set; }
        public int JourneyNumber { get; set; }
        public object Deviations { get; set; }
    }

    public class Train
    {
        public object SecondaryDestinationName { get; set; }
        public object GroupOfLine { get; set; }
        public string TransportMode { get; set; }
        public string LineNumber { get; set; }
        public string Destination { get; set; }
        public int JourneyDirection { get; set; }
        public string StopAreaName { get; set; }
        public int StopAreaNumber { get; set; }
        public int StopPointNumber { get; set; }
        public string StopPointDesignation { get; set; }
        public DateTime TimeTabledDateTime { get; set; }
        public DateTime ExpectedDateTime { get; set; }
        public string DisplayTime { get; set; }
        public int JourneyNumber { get; set; }
        public object Deviations { get; set; }
    }

    public class StopInfo
    {
        public int StopAreaNumber { get; set; }
        public string StopAreaName { get; set; }
        public string TransportMode { get; set; }
        public string GroupOfLine { get; set; }
    }

    public class Deviation
    {
        public string Text { get; set; }
        public object Consequence { get; set; }
        public int ImportanceLevel { get; set; }
    }

    public class StopPointDeviation
    {
        public StopInfo StopInfo { get; set; }
        public Deviation Deviation { get; set; }
    }

    public class ResponseData
    {
        public DateTime LatestUpdate { get; set; }
        public int DataAge { get; set; }
        public List<Metro> Metros { get; set; }
        public List<Bus> Buses { get; set; }
        public List<Train> Trains { get; set; }
        public List<Tram> Trams { get; set; }
        public List<object> Ships { get; set; }
        public List<StopPointDeviation> StopPointDeviations { get; set; }
    }

    public class RealTimeResponse
    {
        public int StatusCode { get; set; }
        public object Message { get; set; }
        public int ExecutionTime { get; set; }
        public ResponseData ResponseData { get; set; }
    }
}
