using MatrixAPI.Data;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MatrixAPI
{
    public partial class Matrix
    {
        private (RestClient, RestRequest) GenerateRequest(string url, Method method, bool setAuthHeader)
        {
            RestClient client = new RestClient(_serverUrl);
            RestRequest request = new RestRequest(url, method);

            //If auth is required, add it to the header - is not added by default
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

        private Response Put(string url, JObject jObject, bool setAuthHeader = false)
        {
            var (client, request) = GenerateRequest(url, Method.PUT, setAuthHeader);

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

        private Task<Stream> GetStream(HttpClient client, string url, bool setAuthHeader = false)
        {
            client.DefaultRequestHeaders.Clear();

            if (setAuthHeader)
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_userData.Token}");

            return client.GetStreamAsync(_serverUrl + url);
        }
    }
}
