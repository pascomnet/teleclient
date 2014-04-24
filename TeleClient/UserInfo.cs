using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeleClient
{
    public class UserInfo
    {
        public string UseBez { get; private set; }
        public string UseName { get; private set; }
        public string Extension { get; private set; }
        public string PhoneDevice { get; set; }

        /// <summary>
        /// Konstrukor für UserInfo
        /// </summary>
        /// <param name="userinfo"></param>
        public UserInfo(Element userinfo)
        {
            if (userinfo == null)
                throw new ArgumentNullException("userinfo is null");

            UseBez = userinfo.GetTag("db_003use_bez", true).ToString();
            UseName = userinfo.GetTag("db_003use_name", true).ToString();
            Extension = userinfo.GetTag("db_009ext_extension", true).ToString();
            if (userinfo.SelectSingleElement("Phonedevice", true) == null)
            {
                PhoneDevice = null;
            }
            else
            {
                PhoneDevice = userinfo.SelectSingleElement("Phonedevice", true).GetAttribute("name");
            }
        }
    }
}