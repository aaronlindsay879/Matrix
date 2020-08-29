﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI.ExtensionMethods
{
    public static class Long
    {
        public static DateTime ToDateTime(this long timestamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            dtDateTime = dtDateTime.AddMilliseconds(timestamp).ToLocalTime();
            return dtDateTime;
        }
    }
}