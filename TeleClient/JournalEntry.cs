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
