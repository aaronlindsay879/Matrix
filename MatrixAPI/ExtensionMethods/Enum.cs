using System;

namespace MatrixAPI.ExtensionMethods
{
    public static class TypesExtensions
    {
        public static string ToString<T>(this T enumToConvert)
        {
            return enumToConvert.ToString().Replace('_', '.');
        }
    }
}
