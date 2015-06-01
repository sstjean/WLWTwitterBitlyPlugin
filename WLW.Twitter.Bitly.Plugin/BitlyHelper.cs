using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace WLW.Twitter.Bitly.Plugin
{
    public class BitlyHelper
    {
        private string login { get; set; }
        private string accessKey { get; set; }

        public BitlyHelper(string login, string accessKey)
        {
            this.login = login;
            this.accessKey = accessKey;
        }

        public string Shorten(string url)
        {

            url = Uri.EscapeUriString(url);
            string reqUri =
                String.Format("https://api-ssl.bitly.com/v3/shorten?" +
                "access_token={0}&longUrl={1}&format=txt",
                this.accessKey, url);

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(reqUri);
            req.Timeout = 10000; // 10 seconds

            // if the function fails and format==txt throws an exception
            Stream stm = req.GetResponse().GetResponseStream();

            using (StreamReader reader = new StreamReader(stm))
                return reader.ReadLine();
        }
    }
}
