using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    public class EntityUpdateException : AbstractBaseExeption
    {
        public EntityUpdateException(string message) : base(message) { }
        public override string Type => "https://miapi.com/errors/entity-update";
        public override string Title => "Entity update error";
    }
}
