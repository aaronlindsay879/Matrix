using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MatrixAPI.Olm
{
    public partial class Olm
    {
        /// <summary>
        /// A method to find the size of an account
        /// </summary>
        /// <returns>The number of bytes needed for an account</returns>
        [DllImport("olm.dll", EntryPoint = "olm_account_size", ExactSpelling = true)]
        public static extern uint GetAccountSize();

        /// <summary>
        /// A method to initialise an account given a location in memory
        /// </summary>
        /// <param name="memory">The location in memory to initialise an account</param>
        /// <returns>A pointer to the initialised account</returns>
        [DllImport("olm.dll", EntryPoint = "olm_account", ExactSpelling = true)]
        public static extern IntPtr InitialiseAccount(IntPtr memory);

        /// <summary>
        /// A method to create an account
        /// </summary>
        /// <param name="account">A pointer giving the memory location to create an account</param>
        /// <param name="random">A byte array containing random data</param>
        /// <param name="randomLength">The number of bits in the random byte array</param>
        /// <returns>A response code</returns>
        [DllImport("olm.dll", EntryPoint = "olm_create_account", ExactSpelling = true)]
        public static extern uint CreateAccount(IntPtr account, byte[] random, uint randomLength);

        /// <summary>
        /// A method to find the length of keys, given an account
        /// </summary>
        /// <param name="account">The account to use for key length calculation</param>
        /// <returns>The number of bytes needed for a key</returns>
        [DllImport("olm.dll", EntryPoint = "olm_account_identity_keys_length", ExactSpelling = true)]
        public static extern uint GetAccountIdentityKeysLength(IntPtr account);

        /// <summary>
        /// A method to write the identity keys of an account to a byte array
        /// </summary>
        /// <param name="account">A pointer giving the memory location of an account</param>
        /// <param name="identityKeys">The byte array to write to</param>
        /// <param name="identityKeysLength">The number of bits in the byte array</param>
        /// <returns>A response code</returns>
        [DllImport("olm.dll", EntryPoint = "olm_account_identity_keys", ExactSpelling = true)]
        public static extern uint WriteAccountIdentityKeys(IntPtr account, byte[] identityKeys, uint identityKeysLength);

        /// <summary>
        /// A method to find the length of one time keys, given an account
        /// </summary>
        /// <param name="account">The account to use for one time key length calculations</param>
        /// <returns>The number of bytes needed for oen time keys</returns>
        [DllImport("olm.dll", EntryPoint = "olm_account_one_time_keys_length", ExactSpelling = true)]
        public static extern uint GetAccountOneTimeKeysLength(IntPtr account);

        /// <summary>
        /// A method to write the one time keys of an account to a byte array
        /// </summary>
        /// <param name="account">A pointer giving the memory location of an account</param>
        /// <param name="identityKeys">The byte array to write to</param>
        /// <param name="identityKeysLength">The number of bits in the byte array</param>
        /// <returns>A response code</returns>
        [DllImport("olm.dll", EntryPoint = "olm_account_one_time_keys", ExactSpelling = true)]
        public static extern uint WriteAccountOneTimeKeys(IntPtr account, byte[] oneTimeKeys, uint oneTimeKeysLength);

        /// <summary>
        /// A method to generate a given number of one time keys
        /// </summary>
        /// <param name="account">The account to use</param>
        /// <param name="numKeys">Number of keys to generate</param>
        /// <param name="random">The random bytes to use</param>
        /// <param name="randomLength">The number of bits in the random byte array</param>
        /// <returns>A response  code</returns>
        [DllImport("olm.dll", EntryPoint = "olm_account_generate_one_time_keys", ExactSpelling = true)]
        public static extern uint GenerateAccountOneTimeKeys(IntPtr account, uint numKeys, byte[] random, uint randomLength);

        [DllImport("olm.dll", EntryPoint = "olm_account_max_number_of_one_time_keys", ExactSpelling = true)]
        public static extern uint GetAccountMaxOneTimeKeys(IntPtr account);
    }
}
