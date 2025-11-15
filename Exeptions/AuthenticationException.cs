using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    public class AuthenticationException : AbstractBaseExeption
    {
        public AuthenticationException(string message) : base(message) { }

        public override string Type => "https://miapi.com/errors/authentication-operation";
        public override string Title => "Database operation error";
    }
}
