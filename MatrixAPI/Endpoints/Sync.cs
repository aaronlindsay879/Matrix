﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Http;

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

            //Use a stream to go string -> json object in order to remove peak RAM usage
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
