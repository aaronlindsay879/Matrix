using MatrixAPI.Data;
using System;

namespace MatrixAPI
{
    public partial class Matrix
    {
        private string _serverUrl;
        private UserData _userData;

        public Matrix(string serverUrl)
        {
            _serverUrl = serverUrl;
        }
    }
}
