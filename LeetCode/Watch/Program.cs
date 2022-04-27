using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Watch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Watch casio = new Casio(WatchType.Sport);
                casio.ShowName();
                casio.ShowTime();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }        
    }
}
