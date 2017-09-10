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
    public class DisruptionManager{
        public async Task<IEnumerable<Disruption>> GetDisruptions(IEnumerable<int> lineNumbers = null, string transportMode = null){
           // return "test";
            
           using (var client = new HttpClient())
            {
               
               var requestString = "http://api.sl.se/api2/deviationsrawdata.json?key=bc2927a9eae442e2b8fd868c7d8c249a";
               
               if(lineNumbers != null && lineNumbers.Any())
               {
                   requestString += "&lineNumber=" + string.Join(",", lineNumbers);
               }
               
               if(!string.IsNullOrWhiteSpace(transportMode)){
                   requestString += "&transportMode=" + transportMode;
               }
               
               var response = await client.GetStringAsync(new Uri(requestString));
               
               var disruptionResponse = JsonConvert.DeserializeObject<DisruptionsResponse>(response);
               
               var allDisruptions = disruptionResponse.ResponseData.Select(d => new Disruption(){
                   Heading = d.Header,
                   Description = d.Details,
                   IsMainNews = d.MainNews,
                   ReportedAt = DateTime.Parse(d.Created),
                   UpdatedAt = DateTime.Parse(d.Updated),
                   TransportMode = transportMode,
                   LineNumber = d.LineNumber
               });
               
               return allDisruptions;

                
            }
            
           
        }
    }
}