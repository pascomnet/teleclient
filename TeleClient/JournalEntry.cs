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
    public class JournalEntry
    {
        // Wir brauchen hier die deutsche Bezeichnung, 
        // weil diese als Header im Journal angezeigt werden
        public string Rufrichtung { get; set; }
        public string Name { get; set; }
        public string Nummer { get; set; }
        public int Dauer { get; set; }

        /// <summary>
        /// Konstruktor für JournalEntry
        /// </summary>
        /// <param name="journalEntry"></param>
        public JournalEntry(Element journalEntry)
        {
            bool Inbound = bool.Parse(journalEntry.GetTag("inbound", true).ToString());
            if (Inbound)
            {
                Rufrichtung = "->";
            }
            else
            {
                Rufrichtung = "<-";
            }
            Name = journalEntry.GetTag("name", true).ToString();
            Nummer = journalEntry.GetTag("number", true).ToString();
            Dauer = int.Parse(journalEntry.GetTag("duration", true).ToString());
        }
    }
}
