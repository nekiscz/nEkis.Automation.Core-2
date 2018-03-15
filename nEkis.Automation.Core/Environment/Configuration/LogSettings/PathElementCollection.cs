using System.Configuration;

namespace nEkis.Automation.Core.Environment.Configuration
{
    [ConfigurationCollection(typeof(PathElement))]
    internal class PathElementCollection : ConfigurationElementCollection
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PathElement)element).File;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new PathElement();
        }

        public new PathElement this[string key]
        {
            get { return (PathElement)BaseGet(key); }
        }

        public PathElement this[int index]
        {
            get { return (PathElement)BaseGet(index); }
        }
    }
}
