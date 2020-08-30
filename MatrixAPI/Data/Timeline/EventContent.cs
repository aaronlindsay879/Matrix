using MatrixAPI.ExtensionMethods;
using Newtonsoft.Json.Linq;

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
            Body = token.IfNotNull("body");
            FormattedBody = token.IfNotNull("formatted_body");
            Membership = token.IfNotNull("membership");
            Url = token.IfNotNull("url");
            LocationUrl = token.IfNotNull("geo_uri");

            if (token["msgtype"] != null)
                MsgType = ((string)token["msgtype"]).ToEnum<EventContentTypes>();
            else
                MsgType = EventContentTypes.none;
        }
    }
}
