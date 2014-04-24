using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agsXMPP;
using agsXMPP.Xml.Dom;
using agsXMPP.protocol.client;
using agsXMPP.sasl;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace TeleClient
{
    public enum DisconnectReason
    {
        LOGOUT,
        ERROR,
        SOCKET_ERROR,
        AUTH_ERROR,
    }

    public class DisconnectEventArgs : EventArgs
    {
        public readonly DisconnectReason Reason;
        public DisconnectEventArgs(DisconnectReason reason)
        {
            this.Reason = reason;
        }
    }

    public class JournalEventArgs : EventArgs
    {
        public List<JournalEntry> Entries { get; private set; }

        public JournalEventArgs(List<JournalEntry> journalEntries)
        {
            Entries = journalEntries;
        }
    }

    public class JournalEntryEventArgs : EventArgs
    {
        public JournalEntry JournalEntry { get; private set; }

        public JournalEntryEventArgs(JournalEntry Entry)
        {
            JournalEntry = Entry;
        }
    }

    public class UserinfoEventArgs : EventArgs
    {
        public UserInfo Userinfo { get; private set; }

        public UserinfoEventArgs(UserInfo userinformation)
        {
            Userinfo = userinformation;
        }
    }

    public class ChanneleventEventArgs : EventArgs
    {
        public ChannelEvent ChannelEvent { get; private set; }

        public ChanneleventEventArgs(ChannelEvent channelevent)
        {
            ChannelEvent = channelevent;
        }
    }

    public class PresenceEventArgs : EventArgs
    {
        public Presence Presence { get; private set; }

        public PresenceEventArgs(Presence presence)
        {
            Presence = presence;
        }
    }

    public interface IConnection
    {
        event EventHandler<DisconnectEventArgs> Disconnected;
        event EventHandler Connected;
        event EventHandler<JournalEventArgs> JournalReceived;
        event EventHandler<UserinfoEventArgs> UserinfoReceived;
        event EventHandler<ChanneleventEventArgs> ChannelEventReceived;
        event EventHandler<PresenceEventArgs> PresenceChanged;
        event EventHandler<JournalEntryEventArgs> JournalEntryReceived;

        void Login(string user, string password, string server);
        void Logout();
        void SendDial(string number);
        void SendHangup();
        void SendOffhook();

        UserInfo UserInfo { get; }
        Presence Presence { get; }
    }

    public class XmppConnection : IConnection
    {
        public UserInfo UserInfo { get;  set;}


        public readonly XmppClientConnection XmppCon;
        public string Username, Password, Server;
        public Presence Presence { get; set; }

        /// <summary>
        /// Konstruktor der Connection
        /// </summary>
        public XmppConnection()
        {
            XmppCon = new XmppClientConnection("mobydick");
            XmppCon.AutoResolveConnectServer = false;

            XmppCon.OnLogin += new ObjectHandler(XmppCon_OnLogin);
            XmppCon.OnAuthError += new XmppElementHandler(XmppCon_OnAuthError);
            XmppCon.OnError += new ErrorHandler(XmppCon_OnError);
            XmppCon.OnSaslStart += new SaslEventHandler(XmppCon_OnSaslStart);
            XmppCon.OnMessage += new MessageHandler(XmppCon_OnMessage);
            XmppCon.OnIq += new IqHandler(XmppCon_OnIq);
            XmppCon.OnSocketError += new ErrorHandler(XmppCon_OnSocketError);
            XmppCon.OnPresence += new PresenceHandler(XmppCon_OnPresence);
            
            Presence = new Presence();
        }

        /// <summary>
        /// Setzen der Telefonpräsenz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pres"></param>
        private void XmppCon_OnPresence(object sender, Presence pres)
        {
            Presence = pres;
        }

        /// <summary>
        /// IqHandler der auf eingehende IQs reagiert 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="iq"></param>
        private void XmppCon_OnIq(object sender, IQ iq)
        {
            Logger(iq.ToString());
            var journalEntries = new List<JournalEntry>();

            //Überprüfen ob wir ein UserInfo bekommen haben
            if (iq.HasTag("UserInfo", true))
            {
                Element userInfoTag = iq.SelectSingleElement("UserInfo", true);
                UserInfo = new UserInfo(userInfoTag);

                this.OnUserinfoReceived(UserInfo);

                // Journal FindOwn IQ senden um das Journal initial zu laden
                IQ JournalIq = new IQ(IqType.get);
                JournalIq.GenerateId();

                CommandTag JournalCmd = new CommandTag("journal");
                
                Element JournalFindOwn = new Element("FindOwn");
                JournalFindOwn.SetAttribute("limit", "30");

                JournalCmd.AddChild(JournalFindOwn);
                JournalIq.AddChild(JournalCmd);

                XmppCon.Send(JournalIq);
            }

            // Überprüfen ob wir ein JournalList bekommen
            if (iq.HasTag("JournalList", true))
            {
                Element journalListTag = iq.SelectSingleElement("JournalList", true);

                // Für jedes JournalEntry in der Liste einen JournalEntry erzeugen und in die Journalliste hängen
                foreach (Element journalEntry in journalListTag.SelectElements("JournalEntry", true))
                {
                    JournalEntry entry = new JournalEntry(journalEntry);
                    journalEntries.Add(entry);
                }

                // Event für JournalReceived feuern
                this.OnJournalReceived(journalEntries);
            }
        }

        /// <summary>
        /// MessageHandler der auf eingehende Messages reagiert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msg"></param>
        private void XmppCon_OnMessage(object sender, agsXMPP.protocol.client.Message msg)
        {
            Logger(msg.ToString());

            // Wenn ein JournalEntry IQ empfangen wird
            if (msg.HasTag("JournalEntry", true))
            {
                Element journalEntry = msg.SelectSingleElement("JournalEntry", true);
                JournalEntry entry = new JournalEntry(journalEntry);

                // Event für JournalEntryReceived feuern
                // damit dieses an die Liste angehängt werden kann
                this.OnJournalEntryReceived(entry);
            }

            // Wenn ein ChannelEvent IQ empfangen wird
            if (msg.HasTag("ChannelEvent", true))
            {
                Element channelevent = msg.SelectSingleElement("ChannelEvent", true);
                ChannelEvent ChannelEvent = new ChannelEvent(channelevent);

                // Event für ChannelEventReceived feuern
                // damit das ClientFrm aktualisiert werden kann
                this.OnChannelEventReceived(ChannelEvent);
            }
        }

        private void XmppCon_OnSaslStart(object sender, SaslEventArgs args)
        {
            args.Auto = true;
            args.Mechanism = agsXMPP.protocol.sasl.Mechanism.GetMechanismName(agsXMPP.protocol.sasl.MechanismType.PLAIN);

        }

        private void XmppCon_OnError(object sender, Exception ex)
        {
            this.OnDisconnected(DisconnectReason.ERROR);
        }

        private void XmppCon_OnSocketError(object sender, Exception ex)
        {
            MessageBox.Show("Der angegebene Server existiert nicht", "Socket Error");
            this.OnDisconnected(DisconnectReason.SOCKET_ERROR);
        }

        private void XmppCon_OnLogin(object sender)
        {
            //ClientInfo schicken
            //IQ erzeugen
            IQ iq = new IQ(IqType.get);
            iq.GenerateId();

            //Command Tag erzeugen
            CommandTag cmd = new CommandTag("xmppuser");

            //ClientInfo erzeugen
            ClientInfo clientinfo = new ClientInfo();
            clientinfo.OsUser = Environment.UserName.ToString();
            clientinfo.Os = Environment.OSVersion.ToString();
            clientinfo.User = XmppCon.Username;
            clientinfo.Jid = XmppCon.MyJID.ToString();
            //clientinfo.clientIp = XmppCo

            //Subscription erzeugen
            Subscription subscription = new Subscription();
            subscription.addSubscription("event", "*", "user");
            subscription.addSubscription("base", "*", "user");
            subscription.addSubscription("journal", "*", "user");

            //IQ zusammenfügen
            clientinfo.AddChild(subscription);
            cmd.AddChild(clientinfo);
            iq.AddChild(cmd);

            //Logger(iq.ToString());

            //ClientInfo senden
            XmppCon.Send(iq);

            this.OnConnected();
        }

        private void XmppCon_OnAuthError(object sender, Element e)
        {
            if (XmppCon.XmppConnectionState != XmppConnectionState.Disconnected)
            {
                XmppCon.Close();
                MessageBox.Show("Benutzername und/oder Passwort falsch", "Auth Error");
            }
            this.OnDisconnected(DisconnectReason.AUTH_ERROR);
        }

        public void SendDial(string number)
        {
            IConnection connection = Program.Connection;

            IQ iq = new IQ(IqType.get);
            iq.GenerateId();

            CommandTag cmd = new CommandTag("base");

            Element dial = new Element("Dial");
            dial.SetAttribute("target", number);
            dial.SetAttribute("prefix", "auto");

            cmd.AddChild(dial);
            iq.AddChild(cmd);

            this.XmppCon.Send(iq);
        }

        /// <summary>
        /// Ein Hangup IQ schicken um das Gespräch zu beenden
        /// </summary>
        public void SendHangup()
        {
            string device = this.UserInfo.PhoneDevice;

            IQ iq = new IQ(IqType.get);
            iq.GenerateId();

            CommandTag cmd = new CommandTag("phone");

            Element hangup = new Element("Hangup");
            hangup.SetAttribute("device", device);

            cmd.AddChild(hangup);
            iq.AddChild(cmd);

            this.XmppCon.Send(iq);
        }

        /// <summary>
        /// Ein Offhook IQ schicken um ein Gespräch anzunehmen
        /// </summary>
        public void SendOffhook()
        {
            IQ iq = new IQ(IqType.get);
            iq.GenerateId();

            CommandTag cmd = new CommandTag("phone");

            Element offhook = new Element("Offhook");
            offhook.SetAttribute("device", this.UserInfo.PhoneDevice);

            cmd.AddChild(offhook);
            iq.AddChild(cmd);

            this.XmppCon.Send(iq);
        }

        /// <summary>
        /// Login-Funktion um sich am Server anzumelden
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="server"></param>
        public void Login(string user, string password, string server)
        {
            this.Username = user;
            this.Password = password;
            this.Server = server;
            XmppCon.ConnectServer = server;
            XmppCon.Open(Username, password);
        }

        /// <summary>
        /// Logout-Funktion um sich vom Server abzumelden
        /// </summary>
        public void Logout()
        {
            if (XmppCon.XmppConnectionState != XmppConnectionState.Disconnected)
            {
                this.OnDisconnected(DisconnectReason.LOGOUT);
                XmppCon.Close();
            }
        }

        protected void OnConnected()
        {
            if (this.Connected != null)
                this.Connected(this, EventArgs.Empty);
            Logger("Connected");
        }

        protected void OnDisconnected(DisconnectReason reason)
        {
            if (this.Disconnected != null)
                this.Disconnected(this, new DisconnectEventArgs(reason));
            Logger("Disconnected ("+reason+")");
        }

        protected void OnJournalReceived(List<JournalEntry> journalEntries)
        {
            if (this.JournalReceived != null)
                this.JournalReceived(this, new JournalEventArgs(journalEntries));
            Logger("Journal received");
        }

        protected void OnJournalEntryReceived(JournalEntry entry)
        {
            if (this.JournalEntryReceived != null)
                this.JournalEntryReceived(this, new JournalEntryEventArgs(entry));
            Logger("Journal Entry received");
        }

        protected void OnUserinfoReceived(UserInfo userinfo)
        {
            if (this.UserinfoReceived != null)
                this.UserinfoReceived(this, new UserinfoEventArgs(userinfo));
            Logger("UserInfo received");
        }

        private void OnChannelEventReceived(ChannelEvent ChannelEvent)
        {
            if (this.ChannelEventReceived != null)
                this.ChannelEventReceived(this, new ChanneleventEventArgs(ChannelEvent));
            Logger("ChannelEvent received");
        }

        private void OnPresenceChanged(Presence Presence)
        {
            if (this.PresenceChanged != null)
                this.PresenceChanged(this, new PresenceEventArgs(Presence));
            Logger("Presence changed");
        }

        /// <summary>
        /// Logger schreibt Loginfos in C:\tmp\log.txt
        /// </summary>
        /// <param name="lines"></param>
        public void Logger(string lines)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\tmp\\log.txt", true);
            file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+": "+lines+"\n");
            file.Close();
        }

        public event EventHandler<DisconnectEventArgs> Disconnected;

        public event EventHandler Connected;

        public event EventHandler<JournalEventArgs> JournalReceived;

        public event EventHandler<UserinfoEventArgs> UserinfoReceived;

        public event EventHandler<ChanneleventEventArgs> ChannelEventReceived;

        public event EventHandler<PresenceEventArgs> PresenceChanged;

        public event EventHandler<JournalEntryEventArgs> JournalEntryReceived;
    }
}
