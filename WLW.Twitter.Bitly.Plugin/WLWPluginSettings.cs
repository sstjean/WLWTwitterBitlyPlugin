using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsLive.Writer.Api;

namespace WLW.Twitter.Bitly.Plugin
{
    public class WLWPluginSettings
    {

        public  const string TITLEMACRO = "<title>";
        public  const string URLMACRO = "<url>";
        public const string DEFAULTTEMPLATE = "[Blog] " + TITLEMACRO + " - " + URLMACRO;

        IProperties m_properties;
        
        public WLWPluginSettings(IProperties properties)
        {
            m_properties = properties;
        }

        public string TwitterAccessTokenOption
        {
            get
            {
                return m_properties.GetString
                    ("TWITTERACCESSTOKEN", string.Empty);
            }
            set
            {
                m_properties.SetString
                    ("TWITTERACCESSTOKEN", value);
            }
        }

        public string TwitterAccessSecretOption
        {
            get
            {
                return m_properties.GetString
                    ("TWITTERACCESSSECRET", string.Empty);
            }
            set
            {
                m_properties.SetString
                    ("TWITTERACCESSSECRET", value);
            }
        }

        public string TwitterPostFormat
        {
            get
            {
                return m_properties.GetString
                    ("TWITTERPOSTFORMAT", DEFAULTTEMPLATE);
            }
            set
            {
                m_properties.SetString
                    ("TWITTERPOSTFORMAT", value);
            }
        }

        public string BitlyAccessTokenOption
        {
            get
            {
                return m_properties.GetString
                    ("BITLYACCESSTOKEN", string.Empty);
            }
            set
            {
                m_properties.SetString
                    ("BITLYACCESSTOKEN", value);
            }
        }

        public string BitlyUserOption
        {
            get
            {
                return m_properties.GetString
                    ("BITLYUSERTOKEN", string.Empty);
            }
            set
            {
                m_properties.SetString
                    ("BITLYUSERTOKEN", value);
            }
        }

    }
}
