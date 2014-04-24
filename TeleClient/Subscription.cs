using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeleClient
{
    class Subscription : Element
    {
        /// <summary>
        /// Konstruktor für Subscription
        /// </summary>
        public Subscription()
        {
            this.TagName = "AddSubscription";
        }

        /// <summary>
        /// Funktion um eine Subscription an ein ClientInfo anzufügen
        /// </summary>
        /// <param name="module"></param>
        /// <param name="type"></param>
        /// <param name="scope"></param>
        public void addSubscription(string module, string type, string scope)
        {
            Element subscription = new Element("Subscription");
            subscription.SetAttribute("module", module);
            subscription.SetAttribute("type", type);
            subscription.SetAttribute("scope", scope);
            this.AddChild(subscription);
        }
    }
}
