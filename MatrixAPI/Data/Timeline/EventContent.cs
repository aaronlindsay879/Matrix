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
            //Fetch data from the body, if it exists
            Body = token.IfNotNull<string>("body");
            FormattedBody = token.IfNotNull<string>("formatted_body");
            Membership = token.IfNotNull<string>("membership");
            Url = token.IfNotNull<string>("url");
            LocationUrl = token.IfNotNull<string>("geo_uri");
            MsgType = token.IfNotNull<EventContentTypes>("msgtype", EventContentTypes.none);
        }
    }
}
