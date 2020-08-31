using MatrixAPI;
using MatrixAPI.Data.Timeline;
using MatrixAPI.Olm;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MatrixClientCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "Matrix client.";

            string username = Environment.GetEnvironmentVariable("Username");
            string password = Environment.GetEnvironmentVariable("Password");

            Matrix api = new Matrix(@"https://matrix.org", username, password, false);
            HttpClient client = new HttpClient();

            try
            {
                //Fetch a list of rooms, and find the id for the first room
                var rooms = api.ListJoinedRooms();
                JObject jObj = JObject.Parse(rooms.Content);
                var roomId = (string)jObj["joined_rooms"].First;

                //Initial sync
                var sync = api.Sync(client);

                EventContent eventContent = new EventContent()
                {
                    Body = "this is a test message",
                    MsgType = EventContentTypes.m_text
                };
                //Uncomment to send test message
                //api.SendMessage(roomId, eventContent);

                Console.Title += $" Connected to: {api.FindDisplayName(sync, roomId)}";

                //Parse sync data, display messages and wait for new messages to be sent
                while (true)
                {
                    string nextBatch = (string)sync["next_batch"];

                    foreach (Event timelineEvent in api.GetMessagesFromSync(sync, roomId))
                        Console.Write(timelineEvent);

                    //Perform a GC -- for some reason this isn't done and leads to memory usage up to 6x more than it should be
                    //The slight impact on CPU performance (which is almost zero) is worth it to reduce RAM usage by such a large factor
                    GC.Collect();
                    sync = api.Sync(client, false, nextBatch, 15000);
                }
            }
            finally
            {
                api.Logout();
            }
        }
    }
}
