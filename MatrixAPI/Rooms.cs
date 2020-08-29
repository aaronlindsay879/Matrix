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
            string joinedRoomsUrl = $@"/_matrix/client/r0/joined_rooms?access_token={_userData.Token}";
            Response response = Get(joinedRoomsUrl);

            return response;
        }

        public Response GetRoomEvent(string roomId, string eventId)
        {
            string roomAliasesUrl = $@"/_matrix/client/r0/rooms/{roomId}/event/{eventId}?access_token={_userData.Token}";
            Response response = Get(roomAliasesUrl);

            return response;
        }

        public Response GetRoomMessages(string roomId)
        {
            string roomAliasesUrl = $@"/_matrix/client/r0/rooms/{roomId.MatrixUrl()}/messages?access_token={_userData.Token}";
            Response response = Get(roomAliasesUrl);

            return response;
        }
    }
}
