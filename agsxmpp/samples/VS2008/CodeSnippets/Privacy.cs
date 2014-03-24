using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using agsXMPP.protocol.iq.privacy;

namespace CodeSnippets
{
    class Privacy
    {
        internal Privacy()
        {
            Privacy1();
        }

        private void Privacy1()
        {
            PrivacyManager pm = new PrivacyManager(new agsXMPP.XmppClientConnection());
            pm.ChangeDefaultList("Test");
        }
    }
}
