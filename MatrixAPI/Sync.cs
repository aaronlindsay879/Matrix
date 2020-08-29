using MatrixAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI
{
    public partial class Matrix
    {
        public Response Sync(bool setOnline = false, string since = null, int? timeOut = null)
        {
            string syncUrl = $@"/_matrix/client/r0/sync?setOnline={(setOnline ? "online" : "offline")}";
            if (!string.IsNullOrEmpty(since)) syncUrl += $"&since={since}";
            if (timeOut.HasValue) syncUrl += $"&timeout={timeOut}";

            Response response = Get(syncUrl, true);

            return response;
        }
    }
}
