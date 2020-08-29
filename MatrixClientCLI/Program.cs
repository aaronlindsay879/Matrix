using MatrixAPI;
using MatrixAPI.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Web;

namespace MatrixClientCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix api = new Matrix(@"https://matrix.org");

            Response response = api.Login(Environment.GetEnvironmentVariable("Username"), Environment.GetEnvironmentVariable("Password"));
            Console.WriteLine($"Logging in\n{response}\n");

            response = api.ListJoinedRooms();
            Console.WriteLine($"Listing joined rooms\n{response}\n");

            Console.WriteLine($"Logging out\n{api.Logout()}\n");
        }
    }
}
