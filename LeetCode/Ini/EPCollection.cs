using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ini
{
    public class EPCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EPTaskElement();
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as EPTaskElement)?.Name;
        }

        new public EPTaskElement this[string name]
        {
            get
            {
                return (EPTaskElement)BaseGet(name);
            }
        }
    }
}
