﻿using Newtonsoft.Json.Linq;
using System;

namespace MatrixAPI.ExtensionMethods
{
    public static class JsonExtensions
    {
        private static T FindGeneric<T>(object obj, string query)
        {
            if (!query.Contains("/"))
                throw new ArgumentException("not valid query");

            string[] parts = query.Split('/');

            dynamic currentValue = obj;
            foreach (string part in parts)
                currentValue = currentValue[part];

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

            if (typeof(T).IsEnum)
                return ((string)token[query]).ToEnum<T>();

            return token[query].ToObject<T>();
        }
    }
}
