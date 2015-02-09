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
using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeleClient
{
    public class UserInfo
    {
        public string UseBez { get; private set; }
        public string UseName { get; private set; }
        public string Extension { get; private set; }
        public string PhoneDevice { get; set; }

        /// <summary>
        /// Konstrukor für UserInfo
        /// </summary>
        /// <param name="userinfo"></param>
        public UserInfo(Element userinfo)
        {
            if (userinfo == null)
                throw new ArgumentNullException("userinfo is null");

            UseBez = userinfo.GetTag("db_003use_bez", true).ToString();
            UseName = userinfo.GetTag("db_003use_name", true).ToString();
            Extension = userinfo.GetTag("db_009ext_extension", true).ToString();
            if (userinfo.SelectSingleElement("Phonedevice", true) == null)
            {
                PhoneDevice = null;
            }
            else
            {
                PhoneDevice = userinfo.SelectSingleElement("Phonedevice", true).GetAttribute("name");
            }
        }
    }
}