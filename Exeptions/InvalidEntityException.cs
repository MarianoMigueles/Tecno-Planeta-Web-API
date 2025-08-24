using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    public class InvalidEntityException : AbstractBaseExeption
    {
        public InvalidEntityException(string message) : base(message) { }
        public override string Type => "https://miapi.com/errors/invalid-entity";
        public override string Title => "Invalid entity";
    }
}
