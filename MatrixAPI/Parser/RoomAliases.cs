﻿using MatrixAPI.ExtensionMethods;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net.Http;

namespace MatrixAPI
{
    public partial class Matrix
    {
        public string FindAlias(JObject syncObject, string roomId)
        {
            var events = syncObject.Find<JToken>($"rooms/join/{roomId}/state/events");
            var nameEvent = events.First(x => (string)x["type"] == "m.room.canonical_alias");
            string alias = nameEvent.Find<string>("content/alias");

            return alias;
        }

        public string FindAlias(HttpClient client, string roomId)
        {
            return FindAlias(Sync(client), roomId);
        }
    }
}
