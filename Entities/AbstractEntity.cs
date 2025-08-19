using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class AbstractEntity
    {
        public required int Id { get; set; }

        public void LogData() { }
    }

}
