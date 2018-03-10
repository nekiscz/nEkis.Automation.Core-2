using System.Configuration;

namespace nEkis.Automation.Core.Environment.Configuration
{
    internal class DateElementCollection : ConfigurationElementCollection
    {
        public DateElementCollection()
        {
            this.AddElementName = "DateSettings";
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as DateElement).DateFormat;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DateElement();
        }

        public new DateElement this[string key]
        {
            get { return base.BaseGet(key) as DateElement; }
        }

        public DateElement this[int ind]
        {
            get { return base.BaseGet(ind) as DateElement; }
        }
    }
}
