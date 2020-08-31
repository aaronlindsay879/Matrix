using MatrixAPI.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI
{
    public partial class Matrix
    {
        public Response UploadIdentityKeys()
        {
            string logOutUrl = @$"/_matrix/client/r0/keys/upload";

            return Post(logOutUrl, new JObject(), true);
        }
    }
}
