using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI.Olm
{
    public partial class Olm
    {
        public static string GetBase64Key(IntPtr account)
        {
            //Find the length of keys in order to create buffer of correct size
            uint keyLength = GetAccountIdentityKeysLength(account);
            byte[] keys = new byte[keyLength];

            //Write the identity keys to the buffer
            WriteAccountIdentityKeys(account, keys, keyLength * 8);

            return Convert.ToBase64String(keys);
        }
    }
}
