using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    public class EntityAlreadyExistsException : AbstractBaseExeption
    {
        public EntityAlreadyExistsException(string message) : base(message) { }

        public override string Type => "https://miapi.com/errors/entity-already-exists";
        public override string Title => "Entity already exists";
    }
}
