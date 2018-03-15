using System.Configuration;

namespace nEkis.Automation.Core.Environment.Configuration
{
    internal class PathElement : ConfigurationElement
    {
        private const string KEY = "File";
        private const string ATTRIBUTE = "Path";

        [ConfigurationProperty(KEY, IsRequired = true, IsKey = true)]
        public string File
        {
            get { return (string)this[KEY]; }
            set { this[KEY] = value; }
        }

        [ConfigurationProperty(ATTRIBUTE, IsRequired = true, IsKey = false)]
        public string Path
        {
            get { return (string)this[ATTRIBUTE]; }
            set { this[ATTRIBUTE] = value; }
        }
    }
}
