using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    public class InvalidStateException : AbstractBaseExeption
    {
        public InvalidStateException(string message) : base(message) { }
        public override string Type => "https://miapi.com/errors/invalid-state";
        public override string Title => "Invalid state";
    }
}
