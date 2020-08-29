using MatrixAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI
{
    public partial class Matrix
    {
        public Response Sync(string since, bool setOnline = false)
        {
            string syncUrl = $@"/_matrix/client/r0/sync?access_token={_userData.Token}&since={since}&setOnline={(setOnline ? "online" : "offline")}";
            Response response = Get(syncUrl);

            return response;
        }
    }
}
