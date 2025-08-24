using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.

namespace Exeptions
{
    public class DatabaseOperationException : AbstractBaseExeption
    {
        public DatabaseOperationException(string message) : base(message) { }

        public override string Type => "https://miapi.com/errors/database-operation";
        public override string Title => "Database operation error";
    }
}
