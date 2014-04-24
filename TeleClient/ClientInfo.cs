using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agsXMPP.Xml.Dom;

namespace TeleClient
{
    public class ClientInfo : Element
    {
        /// <summary>
        /// Konstruktor für ClientInfo
        /// </summary>
        public ClientInfo()
        {
            this.TagName = "ClientInfo";
        }

        public string Os
        {
            get { return GetTag("os"); }
            set { SetTag("os", value.ToString()); }
        }

        public string OsUser
        {
            get { return GetTag("osUser"); }
            set { SetTag("osUser", value.ToString()); }
        }

        public string ClientVersion
        {
            get { return GetTag("clientVersion"); }
            set { SetTag("clientVersion", value.ToString()); }
        }

        public string User
        {
            get { return GetTag("user"); }
            set { SetTag("user", value.ToString()); }
        }

        public string Jid
        {
            get { return GetTag("jid"); }
            set { SetTag("jid", value.ToString()); }
        }

        public string ClientIp
        {
            get { return GetTag("clientIp"); }
            set { SetTag("clientIp", value.ToString()); }
        }

    }
}
