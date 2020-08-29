using MatrixAPI;
using MatrixAPI.Data;
using System;

namespace MatrixClientCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix api = new Matrix(@"https://matrix.org");

            Response response = api.Login(Environment.GetEnvironmentVariable("Username"), Environment.GetEnvironmentVariable("Password"));

            Console.WriteLine(response);
            Console.WriteLine(api.Logout());
        }
    }
}
