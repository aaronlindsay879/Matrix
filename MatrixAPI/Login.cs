using MatrixAPI.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MatrixAPI
{
    partial class Matrix
    {
        public Response Login(string name, string password)
        {
            string loginUrl = @"/_matrix/client/r0/login";

            var loginOptions = JObject.Parse(Get(loginUrl).Content);
            string[] availableOptions = loginOptions["flows"].Select(x => (string)x["type"]).ToArray();

            if (availableOptions.Contains("m.login.password"))
            {
                Response response = Post(loginUrl, UsernamePassword(name, password));
                _userData = new UserData(response.Content);

                return response;
            }
            else
            {
                throw new Exception("login method not supported");
            }
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
