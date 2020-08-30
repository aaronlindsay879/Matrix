using MatrixAPI.ExtensionMethods;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI.Data.Timeline
{
    public struct EventContent
    {
        public string Body;
        public string FormattedBody;
        public string Membership;
        public string Url;
        public string LocationUrl;
        public EventContentTypes MsgType;

        public EventContent(JToken token)
        {
            Body = (string)token["body"];

            MsgType = (token["msgtype"] != null) ? ((string)token["msgtype"]).ToEnum<EventContentTypes>() : EventContentTypes.none;
            FormattedBody = (token["formatted_body"] != null) ? (string)token["formatted_body"] : null;
            Membership = (token["membership"] != null) ? (string)token["formatted_body"] : null;
            Url = (token["url"] != null) ? (string)token["url"] : null;
            LocationUrl = (token["geo_uri"] != null) ? (string)token["geo_uri"] : null;
        }
    }
}
