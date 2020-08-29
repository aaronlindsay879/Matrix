using MatrixAPI.Data;
using System;

namespace MatrixAPI
{
    public partial class Matrix : IDisposable
    {
        private string _serverUrl;
        private UserData _userData;

        public Matrix(string serverUrl)
        {
            _serverUrl = serverUrl;
        }

        public Matrix(string serverUrl, string username, string password)
        {
            _serverUrl = serverUrl;

            Login(username, password);
        }

        public void Dispose()
        {
            Logout();
        }
    }
}
