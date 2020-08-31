using System;

namespace MatrixAPI.ExtensionMethods
{
    static class StringExtensions
    {
        public static string MatrixUrl(this string url)
        {
            //Replace non-websafe chars in room IDs to prevent errors
            return url.Replace("!", "%21")
                      .Replace(":", "%3A");
        }
        public static T ToEnum<T>(this string str)
        {
            //Convert matrix format to this API format (m.room.message -> m_room_message)
            string parsedStr = str.Replace('.', '_');
            object type = Enum.Parse(typeof(T), parsedStr);

            return (T)type;
        }
    }
}
