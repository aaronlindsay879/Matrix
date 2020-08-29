using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixAPI.Data
{
    public struct MessageContent
    {
        public string Body;
        public string MessageType;

        public MessageContent(string body, string messageType)
        {
            Body = body;
            MessageType = messageType;
        }

        public override string ToString()
        {
            return $"type: {MessageType}; body: {Body.PadRight(50, ' ').Substring(0, 50)}";
        }
    }
}
