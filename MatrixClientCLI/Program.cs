using MatrixAPI;
using MatrixAPI.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using MatrixClientCLI.ExtensionMethods;

namespace MatrixClientCLI
{
    class Program
    {
        private static List<string> GetMessagesFromSync(JObject syncObject, string roomId)
        {
            //If no new messages, return empty list
            if (syncObject["rooms"]["join"].Count() == 0)
                return new List<string>();

            //Fetch list of events
            var events = syncObject["rooms"]["join"][roomId]["timeline"]["events"];
            List<string> messages = new List<string>();

            //For every event, generate a message in the format of "[time] name \n message"
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
            Console.CursorVisible = false;

            string username = Environment.GetEnvironmentVariable("Username");
            string password = Environment.GetEnvironmentVariable("Password");

            using (Matrix api = new Matrix(@"https://matrix.org", username, password, false))
            {
                //Fetch a list of rooms, and find the id for the first room
                var rooms = api.ListJoinedRooms();
                JObject jObj = JObject.Parse(rooms.Content);
                var roomId = (string)jObj["joined_rooms"].First;

                //Initial sync
                var sync = api.Sync();

                //Parse sync data, display messages and wait for new messages to be sent
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
            }
        }
    }
}
