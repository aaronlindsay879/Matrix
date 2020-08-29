﻿using MatrixAPI.Data;
using MatrixClientCLI.ExtensionMethods;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixAPI
{
    public partial class Matrix
    {
        public List<Message> GetMessagesFromSync(Response response, string roomId)
        {
            JObject syncObject = JObject.Parse(response.Content);

            //If no new messages, return empty list
            if (syncObject["rooms"]["join"].Count() == 0)
                return new List<Message>();

            //Fetch list of events
            var events = syncObject["rooms"]["join"][roomId]["timeline"]["events"];
            List<Message> messages = new List<Message>();

            //For every event, generate a message in the format of "[time] name \n message"
            foreach (JToken token in events)
            {
                long timestamp = (long)token["origin_server_ts"];
                DateTime time = timestamp.ToDateTime().ToLocalTime();

                Message message = new Message(time, (string)token["sender"], (string)token["content"]["body"]);
                messages.Add(message);
            }

            return messages;
        }

        public List<Message> GetMessagesFromSync(string roomId)
        {
            return GetMessagesFromSync(Sync(), roomId);
        }
    }
}
