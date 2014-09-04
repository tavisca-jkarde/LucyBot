using Lucy.Core.Contracts;
using Matrix;
using Matrix.Xmpp;
using Matrix.Xmpp.Client;
using Matrix.Xmpp.Register;
using Matrix.Xmpp.XData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lucy.Core
{
    public class ChatBot : ICanChat
    {
        private ICommandAdapter _commandAdapter;
        private Matrix.Xmpp.Client.XmppClient _xmppClient;
        private Matrix.Xmpp.Client.PresenceManager _presenceManager;
        private bool _loggedIn;

        ChatRoom room;
        public ChatBot(ICommandAdapter commandAdapter)
        {
            _commandAdapter = commandAdapter;

        }

        public ChatBot() {

            _xmppClient = new Matrix.Xmpp.Client.XmppClient();
            _loggedIn = false;
            room = new ChatRoom();
            Start();

        }
        public void Start(){
            
            string botUserName = "114716_1167039";
            string domain = "chat.hipchat.com";

            _xmppClient.SetUsername(botUserName);
            _xmppClient.SetXmppDomain(domain);
            _xmppClient.Password = "bottheeva";
            
            _xmppClient.OnLogin += new EventHandler<Matrix.EventArgs>(_xmppClient_OnLogin);
            _xmppClient.OnMessage += new EventHandler<Matrix.Xmpp.Client.MessageEventArgs>(_xmppClient_OnMessage);
            _xmppClient.OnPresence += new EventHandler<Matrix.Xmpp.Client.PresenceEventArgs>(_xmppClient_OnPresence);
            _xmppClient.AutoRoster = true;
            
            try
            {                
                _xmppClient.Open();

                Thread.Sleep(100000);
            }
            catch
            {
                Console.WriteLine("Login Failed");
            }

            if (_loggedIn)
            {
                
                _presenceManager = new PresenceManager(_xmppClient);
                Jid sub_jid = "114716_1163345@chat.hipchat.com";

                _presenceManager.Subscribe(sub_jid);
                do
                {

                } while (true);

               
            }
            _xmppClient.Close();
        }

        private void _xmppClient_OnRegisterError(object sender, IqEventArgs e)
        {
            _xmppClient.Close();
        }

              
        private void _xmppClient_OnLogin(object sender, Matrix.EventArgs e)
        {
            int i = 0;
            while (i < 10)
            {
                Console.Write(".");
                i++;
                Thread.Sleep(500);
            }
            _loggedIn = true;
            Console.WriteLine("Successfully logged in!!");
        

        }

       void _xmppClient_OnMessage(object sender, MessageEventArgs e)
        {
            string user = e.Message.From.User;
            string message = e.Message.Body;
            if (message != null)
                if (IsAddressedToBot(message))
                {
                    message = message.Replace("@lucy", "");
                    message = message.TrimStart().TrimEnd();
                    _xmppClient.Send(new Matrix.Xmpp.Client.Message(user + "@conf.hipchat.com", MessageType.groupchat, message));
                    Console.WriteLine(message);
                }
          }

        private string ParseMessage(string message)
        {
            var tempMessage = message.Replace("@lucy", " ");
            tempMessage = message.TrimStart().TrimEnd();
            Console.WriteLine(tempMessage);
            return tempMessage;
        }

        private bool IsAddressedToBot(string message)
        {
            if (message.StartsWith("@lucy"))
                return true;
            return false;
        }

        private void _xmppClient_OnPresence(object sender, PresenceEventArgs e)
        {
            Console.WriteLine("{0}@{1} -> {2}", e.Presence.From.User, e.Presence.From.Server, e.Presence.Type);
            Console.WriteLine();
        }

        private void _presenceManager_OnSubscribe(object sender, PresenceEventArgs e)
        {
            
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
