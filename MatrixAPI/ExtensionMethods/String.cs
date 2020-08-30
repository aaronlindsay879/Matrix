using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
