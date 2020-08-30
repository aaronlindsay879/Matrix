using MatrixAPI.Data;
using MatrixAPI.Data.Timeline;
using MatrixAPI.ExtensionMethods;
using MatrixClientCLI.ExtensionMethods;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace MatrixAPI
{
    public partial class Matrix
    {
        public List<Event> GetMessagesFromSync(JObject syncObject, string roomId)
        {
            //If no new messages, return empty list
            if (syncObject.Find<JToken>("rooms/join").Count() == 0)
                return new List<Event>();

            //Fetch list of events
            var events = syncObject.Find<JToken>($"rooms/join/{roomId}/timeline/events");
            List<Event> eventList = new List<Event>();

            //For every event, generate a message in the format of "[time] name \n message"
            foreach (JObject token in events)
                eventList.Add(new Event(token));

            return eventList;
        }

        public List<Event> GetMessagesFromSync(HttpClient client, string roomId)
        {
            return GetMessagesFromSync(Sync(client), roomId);
        }
    }
}
