using System;
using System.Collections.Generic;
using System.Text;

namespace MillRekrutacja.Core.Exceptions
{
    public class FakeModelNotFoundException : Exception
    {
        public FakeModelNotFoundException(string message) : base(message)
        {
        }
}
}
