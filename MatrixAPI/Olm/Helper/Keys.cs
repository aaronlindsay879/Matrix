using Newtonsoft.Json.Linq;
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

        public static JObject GetOneTimeKeys(IntPtr account)
        {
            //Find the length of keys in order to create buffer of correct size
            uint keyLength = GetAccountOneTimeKeysLength(account);
            byte[] keys = new byte[keyLength];

            //Write the identity keys to the buffer
            WriteAccountOneTimeKeys(account, keys, keyLength * 8);

            string oneTimeKeys = Encoding.UTF8.GetString(keys);
            return JObject.Parse(oneTimeKeys);
        }

        public static void GenerateOneTimeKeys(IntPtr account, uint count, Random random, uint randomLength)
        {
            byte[] randomBytes = new byte[randomLength];
            random.NextBytes(randomBytes);

            Olm.GenerateAccountOneTimeKeys(account, count, randomBytes, randomLength * 8);
        }
    }
}
