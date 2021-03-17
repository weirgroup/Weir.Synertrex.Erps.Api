// <copyright file="GetDeviceTwinData.cs" company="MicrosoftAndWeir">
// Copyright (c) Microsoft Corporation and Weir PLC.  All rights reserved.
// </copyright>

namespace Weir.Synertrex.ERPS.Api
{
    using Microsoft.Azure.WebJobs;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Net;
    using System.Text;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Weir.Synertrex.ERPS.Api.Repository;

    /// <summary>
    /// GetDeviceTwinData class
    /// </summary>
    public static class GetDeviceTwinData
    {
        /// <summary>
        /// Http GET function to fetch Device Twin Data from ERPS database 
        /// </summary>
        /// <param name="httpRequestMessage">HttpRequestMessage object</param>
        /// <param name="request">HttpRequest object</param>
        /// <param name="context">ExecutionContext object</param>
        /// <returns>HttpResponseMessage object</returns>
        [FunctionName("GetDeviceTwinData")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage httpRequestMessage, HttpRequest request, ExecutionContext context)
        {
            string data = string.Empty;

            try
            {
                var physicalIdentifier = request.Query["physicalIdentifier"];
                IERPSRepository erpsRepository = new ERPSRepository();
                data = JsonConvert.SerializeObject(erpsRepository.GetDeviceTwinData(physicalIdentifier));
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

