using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Watch
{

    public enum WatchType
    {
        Sport = 0,
        Quartz,
        Mechanical
    };

    internal abstract class Watch
    {
        protected WatchType type;
        protected String name;

        public WatchType Type { get { return this.type; } }
        public String Name { get { return this.name; } }

        public void ShowName()
        {
            Console.WriteLine($"{this.Name}:{this.Type}");
        }

        public void ShowTime()
        {
            Stream
            Console.WriteLine($"Time:{DateTime.Now.ToString()}");
        }
    }
}
