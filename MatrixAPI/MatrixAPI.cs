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
                string callingMethodName = st.GetFrame(1).GetMethod().Name;

                Console.WriteLine($"method: {callingMethodName} \n{response?.ToString()} \n");
            }
        }
    }
}
