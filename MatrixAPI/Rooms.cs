﻿using MatrixAPI.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI
{
    public partial class Matrix
    {
        public Response ListJoinedRooms()
        {
            string joinedRoomsUrl = @$"/_matrix/client/r0/joined_rooms?access_token={_userData.Token}";

            return Get(joinedRoomsUrl);
        }
    }
}