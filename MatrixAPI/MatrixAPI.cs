using System;

namespace MatrixAPI
{
    public partial class Matrix
    {
        private string _serverUrl;

        public Matrix(string serverUrl)
        {
            _serverUrl = serverUrl;
        }
    }
}
