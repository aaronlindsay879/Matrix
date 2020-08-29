using MatrixAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI
{
    public partial class Matrix
    {
        public Response Sync(string since = null, bool setOnline = false)
        {
            string syncUrl = $@"/_matrix/client/r0/sync?setOnline={(setOnline ? "online" : "offline")}";
            if (!string.IsNullOrEmpty(since)) syncUrl += $"&since={since}";

            Response response = Get(syncUrl, true);

            return response;
        }
    }
}
