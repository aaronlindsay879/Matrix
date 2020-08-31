using MatrixAPI.Data;
using MatrixAPI.Data.Timeline;
using MatrixAPI.ExtensionMethods;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI
{
    public partial class Matrix
    {
        public Response SendEvent(string roomId, EventTypes eventType, JObject jObj)
        {
            string sendEventUrl = @$"/_matrix/client/r0/rooms/{roomId.MatrixUrl()}/send/{eventType.ToString<EventTypes>()}/{_userData.Token.GetHashCode()}";

            return Put(sendEventUrl, jObj, true);
        }

        public Response SendMessage(string roomId, EventContent messageContent)
        {
            dynamic jObject = new JObject();

            jObject.msgtype = messageContent.MsgType.ToString<EventContentTypes>();
            jObject.body = messageContent.Body;

            return SendEvent(roomId, EventTypes.m_room_message, jObject);
        }
    }
}
