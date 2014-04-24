using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agsXMPP.Xml.Dom;

namespace TeleClient
{
    public class JournalEntry
    {
        public string Direction { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int Duration { get; set; }

        /// <summary>
        /// Konstruktor für JournalEntry
        /// </summary>
        /// <param name="journalEntry"></param>
        public JournalEntry(Element journalEntry)
        {
            bool Inbound = bool.Parse(journalEntry.GetTag("inbound", true).ToString());
            if (Inbound)
            {
                Direction = "->";
            }
            else
            {
                Direction = "<-";
            }
            Name = journalEntry.GetTag("name", true).ToString();
            Number = journalEntry.GetTag("number", true).ToString();
            Duration = int.Parse(journalEntry.GetTag("duration", true).ToString());
        }
    }
}
