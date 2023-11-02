using System;

namespace Imagine.Exceptions
{
    public class ConnectivityException : Exception
    {
        public ConnectivityException() :base("No internet connection")
        {

        }
    }
}
