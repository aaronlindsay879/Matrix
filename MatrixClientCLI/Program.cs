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

            Console.WriteLine($"Logging in\n{response}\n");
            Console.WriteLine($"Listing joined rooms\n{api.ListJoinedRooms()}\n");
            Console.WriteLine($"Logging out\n{api.Logout()}\n");
        }
    }
}
