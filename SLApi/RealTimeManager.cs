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

namespace SLapp.SLApi
{
    public class RealTimeManager{
        private readonly IMemoryCache _memoryCache;
        private HttpClient _httpClient;

        public RealTimeManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        private HttpClient HttpClientInstance
        {
            get
            {

                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                }

                return _httpClient;
            }
        }



        
        public async Task<ResponseData> GetRealTimeInfoAsync(string siteId, List<TrafficType> trafficTypes = null){
            var requestString = "http://api.sl.se/api2/realtimedeparturesV4.json?key=0c78a0b0e15b43c2bab46a9cf003d670";

            requestString = $"{requestString}&siteId={siteId}&timeWindow={30}{GetTrafficTypeQueryString(trafficTypes)}";
            var response = await HttpClientInstance.GetStringAsync(new Uri(requestString));

            var realTimeResponse = JsonConvert.DeserializeObject<RealTimeResponse>(response);

            var returnValue = new ResponseData();

            if(realTimeResponse?.ResponseData == null)
                return returnValue;

            return realTimeResponse.ResponseData;

        }

        private string GetTrafficTypeQueryString(List<TrafficType> trafficTypes){
            var query = string.Empty;

            if (trafficTypes == null || !trafficTypes.Any()){
                return query;
            }

            query = AddTrafficType(query, trafficTypes, TrafficType.Bus, "bus");
            query = AddTrafficType(query, trafficTypes, TrafficType.Metro, "metro");
            query = AddTrafficType(query, trafficTypes, TrafficType.Ship, "ship");
            query = AddTrafficType(query, trafficTypes, TrafficType.Train, "train");
            query = AddTrafficType(query, trafficTypes, TrafficType.Tram, "tram");

            return query;
        }

        private string AddTrafficType(string query, List<TrafficType> selectedTraficTypes, TrafficType trafficType, string queryParameter)
        {
            if (selectedTraficTypes.Contains(trafficType))
                query = $"{query}&{queryParameter}=true";
            else
                query = $"{query}&{queryParameter}=false";
            
            return query;
        }

    }

    public enum TrafficType {
        Bus,
        Train,
        Metro,
        Ship,
        Tram
    }
}