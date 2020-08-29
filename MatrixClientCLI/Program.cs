using MatrixAPI;
using MatrixAPI.ExtensionMethods;
using MatrixAPI.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace MatrixClientCLI
{
    class Program
    {
        private static List<string> GetMessagesFromSync(JObject syncObject, string roomId)
        {
            if (syncObject["rooms"]["join"].Count() == 0)
                return new List<string>();

            var events = syncObject["rooms"]["join"][roomId]["timeline"]["events"];
            List<string> messages = new List<string>();

            foreach (JToken token in events)
            {
                long timestamp = (long)token["origin_server_ts"];
                DateTime time = timestamp.ToDateTime().ToLocalTime();

                messages.Add($"[{time:t}] {token["sender"]}\n{token["content"]["body"]}");
            }

            return messages;
        }

        static void Main(string[] args)
        {
            string username = Environment.GetEnvironmentVariable("Username");
            string password = Environment.GetEnvironmentVariable("Password");

            using (Matrix api = new Matrix(@"https://matrix.org", username, password, false))
            {
                var rooms = api.ListJoinedRooms();
                JObject jObj = JObject.Parse(rooms.Content);
                var roomId = (string)jObj["joined_rooms"].First;

                var sync = api.Sync();

                while (true)
                {
                    var events = JObject.Parse(sync.Content);
                    string nextBatch = (string)events["next_batch"];

                    foreach (string message in GetMessagesFromSync(events, roomId))
                    {
                        Console.WriteLine(message + "\n");
                    }

                    sync = api.Sync(false, nextBatch, 15000);
                }

                //api.GetRoomMessages((string)roomId);
            }
        }
    }
}
