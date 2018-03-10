using System.Configuration;

namespace nEkis.Automation.Core.Environment.Configuration
{
    internal class LogSection : ConfigurationSection
    {
        public const string sectionName = "LogSettings";

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public DateElementCollection DateSettings
        {
            get
            {
                return this[""] as DateElementCollection;
            }
        }

        public static LogSection GetSection()
        {
            return (LogSection)ConfigurationManager.GetSection(sectionName);
        }
    }
}
