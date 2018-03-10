using System.Configuration;

namespace nEkis.Automation.Core.Environment.Configuration
{
    internal class CoreSection : ConfigurationSection
    {
        public const string sectionName = "CoreSettings";

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public TestElementCollection TestSettings
        {
            get
            {
                return this[""] as TestElementCollection;
            }
        }

        public static CoreSection GetSection()
        {
            return (CoreSection)ConfigurationManager.GetSection(sectionName);
        }
    }
}
