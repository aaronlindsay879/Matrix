using MatrixAPI.Data;
using System;
using System.Diagnostics;

namespace MatrixAPI
{
    public partial class Matrix : IDisposable
    {
        private string _serverUrl;
        private UserData _userData;
        private bool _log;

        public Matrix(string serverUrl, bool log = false)
        {
            _serverUrl = serverUrl;
            _log = log;
        }

        public Matrix(string serverUrl, string username, string password, bool log = false)
        {
            _serverUrl = serverUrl;
            _log = log;

            Login(username, password);
        }

        public void Dispose()
        {
            Logout();
        }

        private void Log(Response response = null)
        {
            if (_log)
            {
                StackTrace st = new StackTrace(); 
                string netType = st.GetFrame(1).GetMethod().Name;
                string callingMethodName = st.GetFrame(2).GetMethod().Name;
                bool toWrite = true;

                if (response.ToString().Length > 500)
                {
                    Console.Write($"Do you want to log message with length {response.ToString().Length}: ");
                    toWrite = Console.ReadKey().Key == ConsoleKey.Y;
                    Console.Write("\n\n");
                }
                    
                if (toWrite)
                    Console.WriteLine($"method: {callingMethodName} \ntype: {netType} \n{response?.ToString()} \n");
            }
        }
    }
}
