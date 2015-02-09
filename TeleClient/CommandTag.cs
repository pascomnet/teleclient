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
    class CommandTag : Element
    {
        /// <summary>
        /// Konstruktor für CommanTag
        /// </summary>
        /// <param name="module"></param>
        public CommandTag(string module)
        {
            this.TagName = "cmd";
            this.SetNamespace("http://www.pascom.net/mobydick");
            this.SetAttribute("module", module);
        }    
    }
}
