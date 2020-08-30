using System;

namespace MatrixAPI.ExtensionMethods
{
    public static class TypesExtensions
    {
        public static T ToEnum<T>(this string str)
        {
            string parsedStr = str.Replace('.', '_');
            object type = Enum.Parse(typeof(T), parsedStr);

            return (T)type;
        }
    }
}
