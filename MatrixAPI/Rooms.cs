using MatrixAPI.Data;
using MatrixAPI.ExtensionMethods;
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
            string joinedRoomsUrl = $@"/_matrix/client/r0/joined_rooms";
            Response response = Get(joinedRoomsUrl, true);

            return response;
        }

        public Response GetRoomEvent(string roomId, string eventId)
        {
            string roomAliasesUrl = $@"/_matrix/client/r0/rooms/{roomId}/event/{eventId}";
            Response response = Get(roomAliasesUrl, true);

            return response;
        }

        public Response GetRoomMessages(string roomId, string from, string dir)
        {
            string roomAliasesUrl = $@"/_matrix/client/r0/rooms/{roomId.MatrixUrl()}/messages?from={from}&dir={dir}";
            Response response = Get(roomAliasesUrl, true);

            return response;
        }
    }
}
