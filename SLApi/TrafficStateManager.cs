using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using SLapp.SLApi.Models;
using SLapp.SLApi.ResponseModels;
using Newtonsoft.Json;
using System.Linq;

namespace SLapp.SLApi
{
    public class TrafficStateManager
    {

        private HttpClient _httpClient;

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

        public async Task<dynamic> GetTrafficState()
        {
            // return "test";

            var requestString = "http://api.sl.se/api2/trafficsituation.json?key=ec77bb75b2b242e1b3f9a512fcd5e6b9";

            var response = await HttpClientInstance.GetStringAsync(new Uri(requestString));

            var stateResponse = JsonConvert.DeserializeObject<dynamic>(response);

            return stateResponse;
        }
    }
}