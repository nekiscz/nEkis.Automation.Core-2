using System.Configuration;

namespace nEkis.Automation.Core.Environment.Configuration
{
    internal class LogSection : ConfigurationSection
    {
        public const string sectionName = "LogSettings";

        [ConfigurationProperty("DateSettings", IsDefaultCollection = true)]
        public DateElementCollection DateSettings
        {
            get
            {
                return ((DateElementCollection)(base["DateSettings"]));
            }
        }

        [ConfigurationProperty("PathSettings", IsDefaultCollection = false)]
        public PathElementCollection PathSettings
        {
            get
            {
                return ((PathElementCollection)(base["PathSettings"]));
            }
        }

        public static LogSection GetSection()
        {
            return (LogSection)ConfigurationManager.GetSection(sectionName);
        }
    }
}
