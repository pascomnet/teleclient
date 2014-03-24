using System;

using agsXMPP;
using agsXMPP.Xml.Dom;
using agsXMPP.protocol.client;
using agsXMPP.protocol.extensions.amp;

namespace CodeSnippets
{
    class Message
    {
        internal Message()
        {

            Message1();
            Message2();
        }

        private void Message1()
        {
            // transient message (will not be stored offline if the server support AMP)

            /*
            <message to='francisco@hamlet.lit'
                     from='bernardo@hamlet.lit/elsinore'
                     type='chat'
                     id='chatty1'>
              <body>Who&apos;s there?</body>
              <amp xmlns='http://jabber.org/protocol/amp'>
                <rule action='drop' condition='deliver' value='stored'/>
              </amp>
            </message>
            */

            agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();
            msg.To = new Jid("francisco@hamlet.lit");
            msg.From = new Jid("bernardo@hamlet.lit/elsinore");
            msg.Type = MessageType.chat;
            msg.Id = "chatty1";

            msg.Body = "Who&apos;s there?";

            Amp amp = new Amp();
            Rule rule = new Rule(Condition.Deliver, "stored", agsXMPP.protocol.extensions.amp.Action.drop);
            amp.AddRule(rule);

            msg.AddChild(amp);

            Program.Print(msg);

        }

        private void Message2()
        {
            // transient message (will not be stored offline if the server support AMP)

            /*
            <message to='francisco@hamlet.lit'
                     from='bernardo@hamlet.lit/elsinore'
                     type='chat'
                     id='chatty1'>
              <body>Who&apos;s there?</body>
              <amp xmlns='http://jabber.org/protocol/amp'>
                <rule action='drop' condition='deliver' value='stored'/>
              </amp>
            </message>
            */

            agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();
            msg.To = new Jid("francisco@hamlet.lit");
            msg.From = new Jid("bernardo@hamlet.lit/elsinore");
            msg.Type = MessageType.chat;
            msg.Id = "chatty1";

            msg.Body = "Who&apos;s there?";

            Element amp = new Element();
            amp.TagName     = "amp";
            amp.Namespace   = "http://jabber.org/protocol/amp";
            
            Element rule = new Element();
            rule.TagName    = "rule";
            rule.Namespace  = "http://jabber.org/protocol/amp";
            rule.SetAttribute("action", "drop");
            rule.SetAttribute("condition", "deliver");
            rule.SetAttribute("value", "stored");
            
            amp.AddChild(rule);
            msg.AddChild(amp);
                        
            Program.Print(msg);

        }
    }
}
