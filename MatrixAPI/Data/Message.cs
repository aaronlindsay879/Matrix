using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI.Data
{
    public struct Message
    {
        public DateTime Date;
        public string Sender;
        public string Content;

        public Message(DateTime date, string sender, string content)
        {
            Date = date;
            Sender = sender;
            Content = content;
        }

        public override string ToString()
        {
            return $"[{Date:t}] {Sender}\n{Content}";
        }
    }
}
