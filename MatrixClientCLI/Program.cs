using MatrixAPI;
using MatrixAPI.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Web;

namespace MatrixClientCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Environment.GetEnvironmentVariable("Username");
            string password = Environment.GetEnvironmentVariable("Password");

            using (Matrix api = new Matrix(@"https://matrix.org", username, password, true))
            {
                var rooms = api.ListJoinedRooms();

                JObject jObj = JObject.Parse(rooms.Content);
                var roomId = jObj["joined_rooms"].First;
                api.GetRoomMessages((string)roomId);
            }
        }
    }
}
