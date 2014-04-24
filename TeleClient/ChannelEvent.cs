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
