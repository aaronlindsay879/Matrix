using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MatrixAPI.Olm
{
    public partial class Olm
    {
        public static IntPtr NewAccount(Random random, uint randomLength)
        {
            //Find the number of bytes needed for an account, and initialise it
            IntPtr ptr = Marshal.AllocHGlobal((int)GetAccountSize());
            ptr = InitialiseAccount(ptr);

            //Generate a random byte array for the account
            byte[] randomBytes = new byte[randomLength];
            random.NextBytes(randomBytes);

            //Create the account with the random data generated
            CreateAccount(ptr, randomBytes, randomLength * 8);

            return ptr;
        }
    }
}
