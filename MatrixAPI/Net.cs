using MatrixAPI.Data;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace MatrixAPI
{
    public partial class Matrix
    {
        private (RestClient, RestRequest) GenerateRequest(string url, Method method)
        {
            RestClient client = new RestClient(_serverUrl);
            RestRequest request = new RestRequest(url, method);

            return (client, request);
        }
             
        private Response Post(string url, JObject jObject)
        {
            var (client, request) = GenerateRequest(url, Method.POST);

            request.AddParameter("application/json; charset=utf-8", jObject, ParameterType.RequestBody);

            return new Response(client.Execute(request));
        }

        private Response Get(string url)
        {
            var (client, request) = GenerateRequest(url, Method.GET);

            return new Response(client.Execute(request));
        }
    }
}
