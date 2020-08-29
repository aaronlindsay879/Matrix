using MatrixAPI;
using MatrixAPI.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using MatrixClientCLI.ExtensionMethods;
using System.Threading.Tasks;

namespace MatrixClientCLI
{
    class Program
    {
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
                    string nextBatch = (string)JObject.Parse(sync.Content)["next_batch"];

                    foreach (Message message in api.GetMessagesFromSync(sync, roomId))
                        Console.WriteLine(message + "\n");

                    sync = api.Sync(false, nextBatch, 15000);
                }
            }
        }
    }
}
