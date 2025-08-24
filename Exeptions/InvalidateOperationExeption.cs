using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    public class InvalidateOperationExeption : AbstractBaseExeption
    {
        public InvalidateOperationExeption(string message) : base(message) { }
        public override string Type => "https://miapi.com/errors/invalid-Operation";
        public override string Title => "Invalid operation";
    }
}
