using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Student : Human
    {
        public override void Go()
        {
            Console.WriteLine("跳");
        }

        public void Do()
        {
            Console.WriteLine("写作业");
        }
    }
}
