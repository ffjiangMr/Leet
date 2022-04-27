using System;
using System.Configuration;

namespace Ini
{
    public class EPTaskElement : ConfigurationElement
    {
        public EPTaskElement(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public EPTaskElement()
        {                
        }

        [ConfigurationProperty("name")]
        public String Name
        {
            get
            {
                return this["name"] as String;
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("value")]
        public String Value
        {
            get
            {
                return this["value"] as String;
            }
            set
            {
                this["value"] = value;
            }
        }
    }
}
