using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsLive.Writer.Api;

namespace WLWTwitterBitlyPluginTests.Mocks
{
    public class MockPost : IPostInfo
    {


        public ICategoryInfo[] Categories
        {
            get { return null; }
        }

        public string Contents
        {
            get { return "This is a test post from code as I play with Windows Live Writer plugins"; }
        }

        public string Id
        {
            get { return "1"; }
        }

        public bool IsPage
        {
            get { return false; }
        }

        public string Keywords
        {
            get { return string.Empty; }
        }

        public string Permalink
        {
            get { return "http://howstevegotburnedtoday.com/wlwtwitterplugin"; }
        }

        public string Title
        {
            get { return "Test post from code"; }
        }
    }
}
