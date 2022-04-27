using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ini
{
    public class EPEntity
    {
        public List<String> TaskList { get; set; }

        public List<String> QueryList { get; set; }

        public EPEntity()
        {
            this.TaskList = new List<String>();
            this.QueryList = new List<String>();
        }
    }

    public class EPQuery
    {
        public List<String> TaskList { get; set; }
        public EPQuery()
        {
            this.TaskList = new List<String>();
        }
    }

    public class EPTask
    {
        public String Name { get; set; }

        public String Category { get; set; }

        public EPTask()
        {
        }
    }
}
