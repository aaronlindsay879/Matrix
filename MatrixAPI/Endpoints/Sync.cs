using MatrixAPI.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace MatrixAPI
{
    public partial class Matrix
    {
        public JObject Sync(HttpClient client, bool setOnline = false, string since = null, int? timeOut = null)
        {
            //Generate url for sync depending on parameters passed in
            string syncUrl = $@"/_matrix/client/r0/sync?setOnline={(setOnline ? "online" : "offline")}";
            if (!string.IsNullOrEmpty(since)) syncUrl += $"&since={since}";
            if (timeOut.HasValue) syncUrl += $"&timeout={timeOut}";

            JObject obj;

            using (Stream s = GetStream(client, syncUrl, true).Result)
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();

                obj = serializer.Deserialize<JObject>(reader);
            }

            return obj;
        }
    }
}
