/**
 *  TeleClient, a Sample Application to show how to connect to MobyDick XMPP Server
 *  Copyright (C) 2015 pascom Netzwerktechnik GmbH & Co. KG
 *  Author: Jonas Dallmeier
 *
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License along
 *
 *  ith this program; if not, write to the Free Software Foundation, Inc.,
 *  51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. 
 *
 */
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
