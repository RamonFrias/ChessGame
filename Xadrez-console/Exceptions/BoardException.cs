using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_console.Exceptions
{
    class BoardException : Exception
    {
        public BoardException(string message) : base(message) { }
    }
}
