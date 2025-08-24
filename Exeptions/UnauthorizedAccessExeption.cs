using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    public class UnauthorizedAccessExeption : AbstractBaseExeption
    {
        public UnauthorizedAccessExeption(string message) : base(message) { }
        public override string Type => "https://miapi.com/errors/invalid-Access";
        public override string Title => "Invalid Access";
    }
}
