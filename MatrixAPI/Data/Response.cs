using RestSharp;
using System.Net;

namespace MatrixAPI.Data
{
    public struct Response
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Content { get; private set; }

        public Response(IRestResponse restResponse)
        {
            StatusCode = restResponse.StatusCode;
            Content = restResponse.Content;
        }

        public Response(HttpStatusCode statusCode, string content)
        {
            StatusCode = statusCode;
            Content = content;
        }

        public override string ToString()
        {
            return $"status: {StatusCode}\nresponse: {Content}";
        }
    }
}
