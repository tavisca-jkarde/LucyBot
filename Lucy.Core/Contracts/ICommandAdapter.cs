using Lucy.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Core.Contracts
{
    public interface ICommandAdapter
    {
        Command Translate(string message);
    }
}
