using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsLive.Writer.Api;

namespace WLWTwitterBitlyPluginTests.Mocks
{
    public class MockProperties : IProperties
    {
        private Dictionary<string, object> props = new Dictionary<string, object>();

        public string this[string name]
        {
            get { return this.props[name].ToString(); }
            set { this.props[name] = value; }
        }

        public string[] Names
        {
            get { return this.props.Keys.ToArray<string>(); }
        }

        public string[] SubPropertyNames
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool Contains(string name)
        {
            return this.props.ContainsKey(name);
        }

        public bool ContainsSubProperties(string name)
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(string name, bool defaultValue)
        {
            bool retval = defaultValue;

            if (this.Contains(name))
            {
                retval = Convert.ToBoolean(this.props[name]);
            }
            
        return  retval;
     }

        public decimal GetDecimal(string name, decimal defaultValue)
        {
            decimal retval = defaultValue;

            if (this.Contains(name))
            {
                retval = Convert.ToDecimal(this.props[name]);
            }

            return retval;
        }


        public float GetFloat(string name, float defaultValue)
        {
            throw new NotImplementedException();
        }

        public int GetInt(string name, int defaultValue)
        {
            int retval = defaultValue;

            if (this.Contains(name))
            {
                retval = Convert.ToInt32(this.props[name]);
            }

            return retval;
        }


        public string GetString(string name, string defaultValue)
        {
            string retval = defaultValue;

            if (this.Contains(name))
            {
                retval = this.props[name].ToString();
            }

            return retval;
        }


        IProperties GetSubProperties(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(string name)
        {
            this.props.Remove(name);
        }

        public void RemoveAll()
        {
            this.props.Clear();
        }

        public void RemoveSubProperties(string name)
        {
            throw new NotImplementedException();
        }

        public void SetBoolean(string name, bool value)
        {
            this.props[name] = value;
        }

        public void SetDecimal(string name, decimal value)
        {
            this.props[name]=value;
        }

        public void SetFloat(string name, float value)
                    {
            this.props[name]=value;
        }



        public void SetInt(string name, int value)
                    {
            this.props[name]=value;
        }



        public void SetString(string name, string value)
                    {
            this.props[name]=value;
        }

        IProperties IProperties.GetSubProperties(string name)
        {
            throw new NotImplementedException();
        }
    }
}
