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
