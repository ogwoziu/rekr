using System;
using System.Collections.Generic;
using System.Text;

namespace MillRekrutacja.Core.Exceptions
{
    public class FakeModelExistsException : Exception
    {
        public FakeModelExistsException(string message) : base(message)
        {
        }
    }
}
