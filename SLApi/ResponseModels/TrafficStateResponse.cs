using System;
using System.Collections.Generic;

namespace SLApi.ResponseModels
{

    public class LineNumbers
    {
        public bool InputDataIsOptional { get; set; }
        public string Text { get; set; }
    }

    public class Event
    {
        public int EventId { get; set; }
        public string Message { get; set; }
        public LineNumbers LineNumbers { get; set; }
        public bool Expanded { get; set; }
        public bool Planned { get; set; }
        public int SortIndex { get; set; }
        public string TrafficLine { get; set; }
        public string EventInfoUrl { get; set; }
        public object Status { get; set; }
        public string StatusIcon { get; set; }
    }

    public class TrafficType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public object TrafficStatus { get; set; }
        public string StatusIcon { get; set; }
        public List<Event> Events { get; set; }
        public bool Expanded { get; set; }
        public bool HasPlannedEvent { get; set; }
    }

    public class ResponseData
    {
        public List<TrafficType> TrafficTypes { get; set; }
    }

    public class TrafficStateResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public int ExecutionTime { get; set; }
        public ResponseData ResponseData { get; set; }
    }

}
