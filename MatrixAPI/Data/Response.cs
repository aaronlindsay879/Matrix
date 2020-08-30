using RestSharp;
using System.Net;

namespace MatrixAPI.Data
{
    public struct Response
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Content { get; private set; }

        /// <summary>
        /// An object containing information about a HTTP(S) response
        /// </summary>
        /// <param name="restResponse">Response object to parse</param>
        public Response(IRestResponse restResponse)
        {
            StatusCode = restResponse.StatusCode;
            Content = restResponse.Content;
        }

        public override string ToString()
        {
            return $"status: {StatusCode}\nresponse: {Content}";
        }
    }
}
