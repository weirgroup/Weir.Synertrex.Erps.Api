namespace Weir.Synertrex.ERPS.Api
{
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Net;
    using System.Text;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Weir.Synertrex.ERPS.Api.Repository;

    public static class GetDeviceTwinData
    {
        [FunctionName("GetDeviceTwinData")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage httpRequestMessage, HttpRequest request, ExecutionContext context)
        {
            string data = string.Empty;

            try
            {                
                IERPSRepository erpsRepository = new ERPSRepository();
                data = JsonConvert.SerializeObject(erpsRepository.GetDeviceTwinsData());
            }
            catch (Exception ex)
            {
                return httpRequestMessage.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(data, Encoding.UTF8, "application/json")
            };
        }
    }
}

