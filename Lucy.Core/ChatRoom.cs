using Lucy.Core.Contracts;
using Matrix.Xmpp.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Lucy.Core
{
    public class ChatRoom
    {
        List<ChatBot> _chatBotList;
        

        public ChatRoom() 
        {
            

            //xmppClient.OnRosterEnd += delegate { xmppClient.Send(new Message { To = "user2@jabber.org", Type = MessageType.chat, Body = "Hello World" }); };


        }
        public void Join(ICanChat chatter)
        {
            
        }

        public void Leave(ICanChat chatter)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message, ICanChat sender)
        {
            throw new NotImplementedException();
        }

        public bool IsUserPresent(ICanChat chatter)
        {
            throw new NotImplementedException();
        }
    }
}
