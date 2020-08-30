using System;

namespace MatrixAPI.ExtensionMethods
{
    public static class TypesExtensions
    {
        public static T ToEnum<T>(this string str)
        {
            //Convert matrix format to this API format (m.room.message -> m_room_message)
            string parsedStr = str.Replace('.', '_');
            object type = Enum.Parse(typeof(T), parsedStr);

            return (T)type;
        }
    }
}
