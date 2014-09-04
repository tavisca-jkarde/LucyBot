using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Core.Contracts
{
    public interface ICanChat
    {
        string ChatterId { get; set; }

        void Notify(string newMessage);
    }
}
