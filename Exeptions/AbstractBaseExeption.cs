using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    public abstract class AbstractBaseExeption(string message) : Exception(message)
    {
        public abstract string Type { get; }
        public virtual string Title => GetType().Name;
    }
}
