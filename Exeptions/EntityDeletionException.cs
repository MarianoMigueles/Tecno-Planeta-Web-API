using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    public class EntityDeletionException : AbstractBaseExeption
    {
        public EntityDeletionException(string message) : base(message) { }
        public override string Type => "https://miapi.com/errors/entity-deletion";
        public override string Title => "Entity deletion error";
    }
}
