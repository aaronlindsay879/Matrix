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
            string loginUrl = @"/_matrix/client/r0/login";

            //Will add again once matrix has proper support for advertising login options
            //string content = Get(loginUrl).Content;
            //var loginOptions = JObject.Parse(content);

            return Post(loginUrl, UsernamePassword(name, password));
        }

        private JObject UsernamePassword(string username, string password)
        {
            dynamic jsonBody = new JObject();

            jsonBody.type = "m.login.password";
            jsonBody.user = username;
            jsonBody.password = password;

            return jsonBody;
        }
    }
}
