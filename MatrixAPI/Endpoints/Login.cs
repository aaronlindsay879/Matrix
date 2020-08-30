using MatrixAPI.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace MatrixAPI
{
    partial class Matrix
    {
        public Response Logout()
        {
            string logOutUrl = @$"/_matrix/client/r0/logout";

            return Post(logOutUrl, new JObject(), true);
        }

        public Response Login(string name, string password)
        {
            string loginUrl = @"/_matrix/client/r0/login";

            //Fetch the login options from the server and convert to array of strings
            var loginOptions = JObject.Parse(Get(loginUrl).Content);
            string[] availableOptions = loginOptions["flows"].Select(x => (string)x["type"]).ToArray();

            //If username/password login is available, use it - otherwise error
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
            //Generate a json object with correct type, and given username and password
            dynamic jsonBody = new JObject();

            jsonBody.type = "m.login.password";
            jsonBody.user = username;
            jsonBody.password = password;

            return jsonBody;
        }
    }
}
