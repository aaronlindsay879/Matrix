using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MatrixAPI.Data
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Content { get; private set; }

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
