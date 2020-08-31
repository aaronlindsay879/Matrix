using MatrixAPI.Data.Timeline;
using MatrixAPI.ExtensionMethods;
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

            JToken nameEvent;

            try
            {
                nameEvent = events.First(x => (string)x["type"] == "m.room.canonical_alias");
            } 
            catch
            {
                return null;
            }

            string alias = nameEvent.Find<string>("content/alias");

            return alias;
        }

        public string FindAlias(HttpClient client, string roomId)
        {
            return FindAlias(Sync(client), roomId);
        }

        public string FindName(JObject syncObject, string roomId)
        {
            var events = syncObject.Find<JToken>($"rooms/join/{roomId}/timeline/events");

            JToken nameEvent;

            try
            {
                nameEvent = events.First(x => ((string)x["type"]).ToEnum<EventTypes>() == EventTypes.m_room_name);
            }
            catch
            {
                return null;
            }

            string name = nameEvent.Find<string>("content/name");

            return name;
        }

        public string FindDisplayName(JObject syncObject, string roomId)
        {
            if (FindAlias(syncObject, roomId) != null) return FindAlias(syncObject, roomId);
            if (FindName(syncObject, roomId) != null) return FindName(syncObject, roomId);

            return "No name found.";
        }
    }
}
