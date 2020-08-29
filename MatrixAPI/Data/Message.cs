using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI.Data
{
    public struct Message
    {
        public DateTime Date;
        public string Sender;
        public MessageContent messageContent;

        public Message(DateTime date, string sender, JToken content)
        {
            Date = date;
            Sender = sender;

            if (content["membership"] == null)
            {
                messageContent.Body = (string)content["body"] ?? "";
                messageContent.MessageType = (string)content["msg"] ?? "";
            }
            else
            {
                messageContent.Body = "";
                messageContent.MessageType = (string)content["membership"];
            }
        }

        public override string ToString()
        {
            if (messageContent.MessageType == "join" || messageContent.MessageType == "leave")
                return $"[{Date:t}] {Sender} {messageContent.MessageType}";

            return $"[{Date:t}] {Sender}\n{messageContent.Body}";
        }
    }
}
