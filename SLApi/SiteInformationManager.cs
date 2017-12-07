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
    public class SiteInformationManager
    {
        private readonly IMemoryCache _memoryCache;
        private HttpClient _httpClient;

        public SiteInformationManager(IMemoryCache memoryCache)
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

        public async Task<List<SiteInformation>> SearchSitesAsync(string searchQuery, List<TrafficType> trafficTypes = null)
        {
            var requestString = "http://api.sl.se/api2/typeahead.json?key=402a3fe7b58a4663a7129bbb9e7352cb";

            requestString = $"{requestString}&searchstring={searchQuery}";
            var response = await HttpClientInstance.GetStringAsync(new Uri(requestString));

            var siteResponse = JsonConvert.DeserializeObject<SiteInformationResponse>(response);

            var sites = new List<SiteInformation>();

            if (siteResponse?.ResponseData == null || !siteResponse.ResponseData.Any())
                return sites;

            return siteResponse.ResponseData.Select(r => new SiteInformation
            {
                Name = r.Name,
                SiteId = r.SiteId,
                Type = r.Type,
                X = r.X,
                Y = r.Y
            }).ToList();
        }
    }

}