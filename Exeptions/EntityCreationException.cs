using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    public class EntityCreationException : AbstractBaseExeption
    {
        public EntityCreationException(string message) : base(message) { }
        public override string Type => "https://miapi.com/errors/entity-creation";
        public override string Title => "Entity creation error";

    }
}
