using MatrixAPI;
using System;

namespace MatrixClientCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix api = new Matrix(@"https://matrix.org");

            var (status, response) = api.Login(Environment.GetEnvironmentVariable("Username"), Environment.GetEnvironmentVariable("Password"));

            Console.WriteLine($"status: {status}\nresponse: {response}");
        }
    }
}
