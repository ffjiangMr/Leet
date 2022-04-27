using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch
{
    internal class Casio : Watch, ITimer
    {
        public Casio(WatchType type)
        {
            if (this.IsVaildType(type) == true)
            {
                this.type = type;
                this.name = "Casio";
            }
            else
            {
                throw new ArgumentException("类型不支持.");
            }
        }

        public void Timer()
        {
            Console.WriteLine("计时功能");
        }

        private Boolean IsVaildType(WatchType type)
        {
            return type == WatchType.Sport || type == WatchType.Mechanical;
        }
    }
}
