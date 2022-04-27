using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Human
    {

        public string Name { get; set; }

        public Double High { get; set; }

        public virtual void Go()
        {
            Console.WriteLine("走~");
        }

        public void A()
        {
            Console.WriteLine("Human");
        }

    }
}
