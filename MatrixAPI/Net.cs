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
        private (RestClient, RestRequest) GenerateRequest(string url, Method method, bool setAuthHeader)
        {
            RestClient client = new RestClient(_serverUrl);
            RestRequest request = new RestRequest(url, method);

            if (setAuthHeader)
                request.AddHeader("Authorization", $"Bearer {_userData.Token}");

            return (client, request);
        }
             
        private Response Post(string url, JObject jObject, bool setAuthHeader = false)
        {
            var (client, request) = GenerateRequest(url, Method.POST, setAuthHeader);

            request.AddParameter("application/json; charset=utf-8", jObject, ParameterType.RequestBody);
            Response response = new Response(client.Execute(request));

            Log(response);
            return response;
        }

        private Response Get(string url, bool setAuthHeader = false)
        {
            var (client, request) = GenerateRequest(url, Method.GET, setAuthHeader);

            Response response = new Response(client.Execute(request));

            Log(response);
            return response;
        }
    }
}
