using MatrixAPI.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MatrixAPI
{
    partial class Matrix
    {
        public Response Login(string name, string password)
        {
            dynamic jsonBody = new JObject();

            jsonBody.type = "m.login.password";
            jsonBody.user = name;
            jsonBody.password = password;

            return Post(@"/_matrix/client/r0/login", jsonBody);
        }
    }
}
