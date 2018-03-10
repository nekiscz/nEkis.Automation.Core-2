using System.Configuration;

namespace nEkis.Automation.Core.Environment.Configuration
{
    internal class DateElement : ConfigurationElement
    {
        private const string KEY = "DateFormat";
        private const string ATTRIBUTE = "Format";

        [ConfigurationProperty(KEY, IsRequired = true, IsKey = true)]
        public string DateFormat
        {
            get { return (string)this[KEY]; }
            set { this[KEY] = value; }
        }

        [ConfigurationProperty(ATTRIBUTE, IsRequired = true, IsKey = false)]
        public string Format
        {
            get { return (string)this[ATTRIBUTE]; }
            set { this[ATTRIBUTE] = value; }
        }
    }
}
