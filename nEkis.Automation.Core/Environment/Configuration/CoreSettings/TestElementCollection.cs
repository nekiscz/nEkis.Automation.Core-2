using System.Configuration;

namespace nEkis.Automation.Core.Environment.Configuration
{
    internal class TestElementCollection : ConfigurationElementCollection
    {
        public TestElementCollection()
        {
            this.AddElementName = "TestSettings";
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as TestElement).TestSetting;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new TestElement();
        }

        public new TestElement this[string key]
        {
            get { return base.BaseGet(key) as TestElement; }
        }

        public TestElement this[int ind]
        {
            get { return base.BaseGet(ind) as TestElement; }
        }
    }
}
