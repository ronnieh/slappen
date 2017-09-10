using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using SLapp.SLApi.Models;
using SLapp.SLApi.ResponseModels;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;

namespace TrafikApi.SLApi.Lines
{
    public class LinesManager{
        private readonly IMemoryCache _memoryCache;
        private readonly string _linesCacheKey = "LinesManager_GetAllLines";
        private readonly string _journeyCacheKey = "LinesManager_GetAllJourneyPoints";
        private readonly string _stopPointCacheKey = "LinesManager_GetAllStopPoints";
        
        public LinesManager(IMemoryCache memoryCache){
            _memoryCache = memoryCache;
        }
        
        public async Task<IEnumerable<Line>> GetLines(string transportMode = null){
            var allLines = await GetAllLines();
            
            if(string.IsNullOrWhiteSpace(transportMode))
                return allLines;
                
            return allLines.Where(l => l.TransportMode.Equals(transportMode, StringComparison.CurrentCultureIgnoreCase));
        }
        
        public async Task<IEnumerable<JourneyPoint>> GetJourneyPoints(int? lineNumber = null){
            var journeyPoints = await GetAllJourneyPoints();
            
            if(lineNumber.HasValue){
                journeyPoints = journeyPoints.Where(j => j.LineNumber == lineNumber.Value);
            }
            
            return journeyPoints;
        }
        
        public async Task<IEnumerable<string>> GetTransportModes(){
            var allLines = await GetAllLines();
            
            return allLines.Select(l => l.TransportMode).Distinct();
        }
        private async Task<IEnumerable<Line>> GetAllLines(){
            var cachedLines = _memoryCache.Get(_linesCacheKey) as IEnumerable<Line>;
           
            if(cachedLines != null)
                return cachedLines;
            
            using (var client = new HttpClient())
            {
               
               var requestString = "http://api.sl.se/api2/LineData.json?model=line&key=cb055a80d93d47b4bb5811e28382b6fd";
               
               
               var response = await client.GetStringAsync(new Uri(requestString));
               
               var linesResponse  = JsonConvert.DeserializeObject<LinesRootResponse>(response);
               
               var allLines = linesResponse.ResponseData.Result.Select(l => new Line(){
                   LineNumber = l.LineNumber,
                   LineDesignation = l.LineDesignation,
                   TransportName = l.DefaultTransportMode,
                   TransportMode = l.DefaultTransportModeCode 
               });
               
               _memoryCache.Set(
                _linesCacheKey, 
                allLines,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                
               return allLines;

                
            }
        }
        
        private async Task<IEnumerable<JourneyPoint>> GetAllJourneyPoints(){
            var cachedPoints = _memoryCache.Get(_journeyCacheKey) as IEnumerable<JourneyPoint>;
           
            if(cachedPoints != null)
                return cachedPoints;
            
            using (var client = new HttpClient())
            {
               
               var requestString = "http://api.sl.se/api2/LineData.json?model=jour&key=cb055a80d93d47b4bb5811e28382b6fd";
               
               
               var response = await client.GetStringAsync(new Uri(requestString));
               var allStopPoints = await GetAllStopPoints();
               
               var pointsResponse  = JsonConvert.DeserializeObject<JourneyPointRootObject>(response);
               
               var allJourneyPoints = pointsResponse.ResponseData.Result.Select(j => new JourneyPoint(){
                   LineNumber = j.LineNumber,
                   DirectionCode = j.DirectionCode,
                   JourneyPatternPointNumber = j.JourneyPatternPointNumber,
                   ExistsFromDate = j.ExistsFromDate,
                   StopPoint = allStopPoints.ContainsKey(j.JourneyPatternPointNumber) ? allStopPoints[j.JourneyPatternPointNumber] : null
               });
               
               _memoryCache.Set(
                _journeyCacheKey, 
                allJourneyPoints,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                
               return allJourneyPoints;

                
            }
        }
        
        public async Task<ConcurrentDictionary<int, StopPoint>> GetAllStopPoints(){
            var stopPointsDictionary = _memoryCache.Get(_stopPointCacheKey) as ConcurrentDictionary<int, StopPoint>;
           
            if(stopPointsDictionary != null)
                return stopPointsDictionary;
            
            using (var client = new HttpClient())
            {
               
               var requestString = "http://api.sl.se/api2/LineData.json?model=stop&key=cb055a80d93d47b4bb5811e28382b6fd";
               
               
               var response = await client.GetStringAsync(new Uri(requestString));
               
               var stopPointsResponse  = JsonConvert.DeserializeObject<StopPointRootObject>(response);
               
               var allStopPoints = stopPointsResponse.ResponseData.Result.Select(s => new StopPoint(){
                   StopPointNumber = s.StopPointNumber,
                   StopPointName = s.StopPointName,
                   StopAreaNumber = s.StopAreaNumber,
                   LocationNorthingCoordinate = s.LocationNorthingCoordinate,
                   LocationEastingCoordinate = s.LocationEastingCoordinate,
                   ZoneShortName = s.ZoneShortName,
                   StopAreaTypeCode = s.StopAreaTypeCode,
                   ExistsFromDate = s.ExistsFromDate
               });
               
               stopPointsDictionary = new ConcurrentDictionary<int, StopPoint>();
               
               allStopPoints.ToList().ForEach(s => stopPointsDictionary.TryAdd(s.StopPointNumber, s));
               
               _memoryCache.Set(
                _stopPointCacheKey, 
                allStopPoints,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                
               return stopPointsDictionary;

                
            }
        }
    }
}