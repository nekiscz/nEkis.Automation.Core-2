using System.Configuration;

namespace nEkis.Automation.Core.Environment.Configuration
{
    internal class TestElement : ConfigurationElement
    {
        private const string KEY = "TestSetting";
        private const string ATTRIBUTE = "Value";

        [ConfigurationProperty(KEY, IsRequired = true, IsKey = true)]
        public string TestSetting
        {
            get { return (string)this[KEY]; }
            set { this[KEY] = value; }
        }

        [ConfigurationProperty(ATTRIBUTE, IsRequired = true, IsKey = false)]
        public string Value
        {
            get { return (string)this[ATTRIBUTE]; }
            set { this[ATTRIBUTE] = value; }
        }
    }
}
