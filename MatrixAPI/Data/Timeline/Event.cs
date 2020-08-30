using MatrixAPI.ExtensionMethods;
using MatrixClientCLI.ExtensionMethods;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI.Data.Timeline
{
    public struct Event
    {
        public DateTime Date;
        public string Sender;
        public EventTypes EventType;
        public EventContent Content;

        public Event(JObject obj)
        {
            Date = ((long)obj["origin_server_ts"]).ToDateTime();
            Sender = (string)obj["sender"];
            EventType = ((string)obj["type"]).ToEnum<EventTypes>();
            Content = new EventContent(obj["content"]);
        }

        public override string ToString()
        {
            switch (EventType)
            {
                case EventTypes.m_room_member:
                    return $"{Sender} has {(Content.Membership == "join" ? "joined" : "left")}\n";
                case EventTypes.m_room_message:
                    return $"[{Date:t}] {Sender}\n{Content.Body}\n";
                case EventTypes.m_reaction:
                    return "";
            }

            return "";
        }
    }
}
