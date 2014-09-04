using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Core.Model
{
    public class Command
    {
        public Command()
        {
            this.Arguments = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }


        public string Type { get; set; }

        public Dictionary<string, string> Arguments { get; private set; }
    }
}
