using MatrixAPI.ExtensionMethods;
using MatrixClientCLI.ExtensionMethods;
using Newtonsoft.Json.Linq;
using System;

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
            //Fetch data from a timeline event
            Date = ((long)obj["origin_server_ts"]).ToDateTime();
            Sender = (string)obj["sender"];
            EventType = ((string)obj["type"]).ToEnum<EventTypes>();
            Content = new EventContent(obj["content"]);
        }

        private string BodyString()
        {
            //Return different values for the body text depending on event body type
            switch (Content.MsgType)
            {
                case EventContentTypes.m_text:
                    return Content.Body;
                case EventContentTypes.m_emote:
                    return $"{Sender} {Content.Body}";
                case EventContentTypes.m_notice:
                    return $"Notice: {Content.Body}";
                case EventContentTypes.m_image:
                case EventContentTypes.m_file:
                case EventContentTypes.m_audio:
                case EventContentTypes.m_video:
                    return $"Url: {Content.Url}\nDescription: {Content.Body}";
                case EventContentTypes.m_location:
                    return $"Body: {Content.Body}\nLocation: {Content.LocationUrl}";

                default:
                    return "";
            }
        }

        public override string ToString()
        {
            //Format the entire message differently depending upon the event type
            switch (EventType)
            {
                case EventTypes.m_room_member:
                    return $"[{Date:t}] {Sender} {(Content.Membership == "join" ? "joined" : "left")}\n";
                case EventTypes.m_room_message:
                    return $"[{Date:t}] {Sender}\n{BodyString()}\n";
                case EventTypes.m_room_redaction:
                    return $"[{Date:t}] {Sender}\nprevious message redacted\n";
                case EventTypes.m_reaction:
                    return "";

                default:
                    return "";
            }
        }
    }
}
