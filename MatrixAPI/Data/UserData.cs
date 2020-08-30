using Newtonsoft.Json.Linq;

namespace MatrixAPI.Data
{
    public struct UserData
    {
        public string MatrixID { get; private set; }
        public string DeviceID { get; private set; }
        public string Token { get; private set; }
        public string HomeServer { get; private set; }

        /// <summary>
        /// An object containing data about a user
        /// </summary>
        /// <param name="content">A string containing JSON data to parse</param>
        public UserData(string content)
        {
            JObject obj = JObject.Parse(content);

            MatrixID = (string)obj["user_id"];
            DeviceID = (string)obj["device_id"];
            Token = (string)obj["access_token"];
            HomeServer = (string)obj["home_server"];
        }
    }
}
