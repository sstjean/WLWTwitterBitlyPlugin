using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsLive.Writer.Api;

namespace WLWTwitterBitlyPluginTests.Mocks
{
    public class MockPublishingContext : IPublishingContext
    {

        public string AccountId
        {
            get { return "a"; }
        }

        public string BlogName
        {
            get { return "How Steve Got Burned Today"; }
        }

        public System.Drawing.Color? BodyBackgroundColor
        {
            get { return System.Drawing.Color.White; }
        }

        public string HomepageUrl
        {
            get { return "http://howstevegotburnedtoday.com"; }
        }

        public IPostInfo PostInfo
        {
            get { return new MockPost(); }
        }

        public string ServiceName
        {
            get { return string.Empty; }
        }

        public SupportsFeature SupportsEmbeds
        {
            get { return 0; }
        }

        public SupportsFeature SupportsImageUpload
        {
            get { return 0; }
        }

        public SupportsFeature SupportsScripts
        {
            get { return 0; }
        }
    }
}
