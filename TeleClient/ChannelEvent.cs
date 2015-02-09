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
    public class ChannelEvent
    {
        public string EventId { get; set; }
        public string EventType { get; set; }
        public bool Outbound { get; set; }
        public bool Internal { get; set; }
        public string SourceName { get; set; }
        public string SourceNumber { get; set; }
        public string TargetName { get; set; }
        public string TargetNumber { get; set; }
        public string Device { get; set; }

        /// <summary>
        /// Konstruktor für ChannelEvent
        /// </summary>
        /// <param name="channelEvent"></param>
        public ChannelEvent(Element channelEvent)
        {
            if (channelEvent == null)
                throw new ArgumentNullException("channelEvent is null");

            EventId = channelEvent.GetTag("eventId", true).ToString();
            EventType = channelEvent.GetTag("eventType", true).ToString();
            Outbound = Convert.ToBoolean(channelEvent.GetTag("outbound", true).ToString());
            Internal = Convert.ToBoolean(channelEvent.GetTag("internal", true).ToString());
            SourceName = channelEvent.GetTag("sourceName", true).ToString();
            SourceNumber = channelEvent.GetTag("sourceNumber", true).ToString();
            TargetName = channelEvent.GetTag("targetName", true).ToString();
            TargetNumber = channelEvent.GetTag("targetNumber", true).ToString();
            Device = channelEvent.GetTag("device", true).ToString();
        }
    }
}
