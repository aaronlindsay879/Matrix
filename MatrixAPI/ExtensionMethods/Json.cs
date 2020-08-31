using Newtonsoft.Json.Linq;
using System;

namespace MatrixAPI.ExtensionMethods
{
    public static class JsonExtensions
    {
        private static T FindGeneric<T>(object obj, string query)
        {
            //Only support queries with 2 or more sections
            if (!query.Contains("/"))
                throw new ArgumentException("not valid query");

            string[] parts = query.Split('/');

            //Traverse the json object one query at a time
            dynamic currentValue = obj;
            foreach (string part in parts)
            {
                try
                {
                    currentValue = currentValue[part];
                }
                catch
                {
                    return default;
                }
            }

            //Return the final object
            return (T)currentValue;
        }

        public static T Find<T>(this JObject obj, string query)
        {
            return FindGeneric<T>(obj, query);
        }

        public static dynamic Find(this JObject token, string query)
        {
            return FindGeneric<dynamic>(token, query);
        }

        public static T Find<T>(this JToken token, string query)
        {
            return FindGeneric<T>(token, query);
        }

        public static dynamic Find(this JToken token, string query)
        {
            return FindGeneric<dynamic>(token, query);
        }

        public static T IfNotNull<T>(this JToken token, string query, dynamic defaultValue = null)
        {
            if (token[query] == null)
                return defaultValue;

            //Special case for enum, since simple casting doesn't work
            if (typeof(T).IsEnum)
                return ((string)token[query]).ToEnum<T>();

            return token[query].ToObject<T>();
        }
    }
}
