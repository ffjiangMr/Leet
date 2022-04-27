using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ini
{
    public class EPSection : ConfigurationSection
    {
        [ConfigurationProperty("tasks")]
        public EPCollection Tasks
        {
            get
            {
                return this["tasks"] as EPCollection;
            }

            set
            {
                this["tasks"] = value;
            }
        }
    }
}
