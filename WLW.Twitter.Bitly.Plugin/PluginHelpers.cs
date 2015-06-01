using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WLW.Twitter.Bitly.Plugin
{
    public static class PluginHelpers
    {
        public struct TweetTemplate
        {
            public string userTemplate;
            public string formatString;

            public TweetTemplate(string template)
            {
                userTemplate = template;
                formatString = string.Empty;
            }

            public bool HasTitle
            {
                get { return userTemplate.Contains(WLWPluginSettings.TITLEMACRO); }
            }
            
            public bool HasUrl
            {
               get{ return  userTemplate.Contains(WLWPluginSettings.URLMACRO);}
            }

            public bool OnlyHasUrl
            {
                get { return HasUrl && !HasTitle; }
            }

            public bool OnlyHasTitle
            {
                get { return HasTitle && !HasUrl; }
            }

            public int UsedTweetSpace
            {
                get
                {
                    return formatString.Replace("{0}", string.Empty)
                                       .Replace("{1}", string.Empty)
                                       .Length;
                }
            }

        }

        public static TweetTemplate ConstructTweetFormat(string template)
        {
            TweetTemplate fixedTemplate = new TweetTemplate(template);

            if (fixedTemplate.HasUrl && !fixedTemplate.HasTitle)
            {
                //URL only in template so it will be the {0} placeholder
                fixedTemplate.formatString = template.Replace(WLWPluginSettings.URLMACRO, "{0}");
            }
            else
            {
                //All other cases, Title is the {0} parameter
                fixedTemplate.formatString = template.Replace(WLWPluginSettings.TITLEMACRO, "{0}")
                                               .Replace(WLWPluginSettings.URLMACRO, "{1}");
            }

            return fixedTemplate;
        }

       

    }
}
