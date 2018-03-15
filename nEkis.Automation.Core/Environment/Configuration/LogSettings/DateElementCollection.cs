using System.Configuration;

namespace nEkis.Automation.Core.Environment.Configuration
{
    [ConfigurationCollection(typeof(DateElement))]
    internal class DateElementCollection : ConfigurationElementCollection
    {

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DateElement)element).DateFormat;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DateElement();
        }   

        public new DateElement this[string key]
        {
            get { return (DateElement)BaseGet(key); }
        }

        public DateElement this[int index]
        {
            get { return (DateElement)BaseGet(index); }
        }
    }
}
