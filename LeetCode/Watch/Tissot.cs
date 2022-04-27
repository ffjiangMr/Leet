using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch
{
    internal class Tissot : Watch, ILuminous
    {
        public Tissot(WatchType type)
        {
            if (this.IsVaildType(type) == true)
            {
                this.type = type;
                this.name = "Tissot";
            }
            else
            {
                throw new ArgumentException("类型不支持.");
            }
        }

        public void Luminous()
        {
            Console.WriteLine("夜光功能.");
        }

        private Boolean IsVaildType(WatchType type)
        {
            return type == WatchType.Quartz || type == WatchType.Mechanical;
        }
    }
}
