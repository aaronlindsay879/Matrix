using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI.ExtensionMethods
{
    static class String
    {
        public static string MatrixUrl(this string url)
        {
            return url.Replace("!", "%21")
                      .Replace(":", "%3A");
        }
    }
}
