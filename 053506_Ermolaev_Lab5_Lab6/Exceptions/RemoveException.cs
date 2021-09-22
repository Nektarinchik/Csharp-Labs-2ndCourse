using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Ermolaev_Lab5
{
    class RemoveException : ArgumentException
    {
        public RemoveException(string message)
            : base(message)
        { }
    }
}
