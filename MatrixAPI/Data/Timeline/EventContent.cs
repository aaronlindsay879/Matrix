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

        /// <summary>
        /// An object containing information about the content of an event
        /// </summary>
        /// <param name="token">Content token to parse</param>
        public EventContent(JToken token)
        {
            //Fetch data from the token, if it exists
            Body = token.IfNotNull<string>("body");
            FormattedBody = token.IfNotNull<string>("formatted_body");
            Membership = token.IfNotNull<string>("membership");
            Url = token.IfNotNull<string>("url");
            LocationUrl = token.IfNotNull<string>("geo_uri");
            MsgType = token.IfNotNull<EventContentTypes>("msgtype", EventContentTypes.none);
        }
    }
}
