using Lucy.Core.Contracts;
using Matrix.Xmpp;
using Matrix.Xmpp.Client;
using Matrix.Xmpp.Register;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Core
{
    public class ChatBot : ICanChat
    {
        private ICommandAdapter _commandAdapter;
        XmppClient xmppClient = new XmppClient();
        ChatRoom room;
        public ChatBot(ICommandAdapter commandAdapter)
        {
            _commandAdapter = commandAdapter;

        }

        public ChatBot() {

          //  xmppClient.OnRegister += new EventHandler<Matrix.EventArgs>(xmppClient_OnRegister);
            //xmppClient.OnRegisterInformation += new EventHandler<Matrix.Xmpp.Register.RegisterEventArgs>(xmppClient_OnRegisterInformation);
            //xmppClient.OnRegisterError += new EventHandler<Matrix.Xmpp.Client.IqEventArgs>(xmppClient_OnRegisterError);
            xmppClient.OnMessage += new EventHandler<MessageEventArgs>(xmppClient_OnMessage);

            xmppClient.SetXmppDomain( "chat.hipchat.com");
            xmppClient.SetUsername("jkarde@tavisca.com");
            xmppClient.Password = "kaddy2014";
            xmppClient.Status = "Nigger";
            xmppClient.Show = Matrix.Xmpp.Show.chat; 
            room = new ChatRoom();
            
            var msg = new Matrix.Xmpp.Client.Message
            {
                Type = MessageType.chat,
                To = "prathod@tavisca.com",
                Body = "Hello World!"
            };
           xmppClient.Send(msg);
           xmppClient.OnLogin += new EventHandler<Matrix.EventArgs>(xmpp_OnLogin);
           xmppClient.OnAuthError += new EventHandler<Matrix.Xmpp.Sasl.SaslEventArgs>(XmppClient_OnAuthError);
           xmppClient.OnError += new EventHandler<Matrix.ExceptionEventArgs>(XmppClient_OnError);
           xmppClient.OnRosterEnd += new EventHandler<Matrix.EventArgs>(XmppClient_OnRosterEnd);
           xmppClient.Open();

           xmppClient.SendPresence(Show.chat, "Online");
           xmppClient.OnPresence += new EventHandler<PresenceEventArgs>(XmppClient_OnPresence);
        }

        private void XmppClient_OnPresence(object sender, PresenceEventArgs pres)
        {
            if (!pres.Presence.Type.Equals("unavailable"))
                Console.WriteLine("{0}@{1}  {2}", pres.Presence.From.User,
                    pres.Presence.From.Server, pres.Presence.Type);
        }

        private void XmppClient_OnRosterEnd(object sender, Matrix.EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void XmppClient_OnError(object sender, Matrix.ExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void XmppClient_OnAuthError(object sender, Matrix.Xmpp.Sasl.SaslEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void xmppClient_OnMessage(object sender, MessageEventArgs e)
        {
            Debug.WriteLine("hell0 in onmessage");
            throw new NotImplementedException();
        }

        private void xmppClient_OnRegisterError(object sender, IqEventArgs e)
        {
            // registration failed.
            throw new NotImplementedException();
        }

        private void xmppClient_OnRegisterInformation(object sender, RegisterEventArgs registerEventArgs)
        {
            throw new NotImplementedException();
        }

        private void xmppClient_OnRegister(object sender, EventArgs registerEventArgs) {
            throw new NotImplementedException();
        }

        private void xmpp_OnLogin(object sender, Matrix.EventArgs e)
        {
            Debug.WriteLine("in onlogin ");
        }
        public void Notify(string newMessage)
        {
            throw new NotImplementedException();
        }

        public string ChatterId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
