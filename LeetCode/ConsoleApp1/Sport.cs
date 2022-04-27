using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp1
{
    internal class Sport : Human
    {
        public override void Go()
        {                
            Console.WriteLine("跑");
        }

        public void Train()
        {
            Console.WriteLine("训练");
        }
    }
}
