using Samples.AspNet;

using System;
using System.Collections.Generic;
using System.Configuration;

namespace Ini
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var demo = new List<string>() { @"C:\Users\Neusoft\Downloads\20220216-enstar-demotion-revision\ExecutionPlan_L2_Ann.ini" };
            IniHelper iniHelper = new IniHelper(demo);
            iniHelper.Load();
            // Get current configuration file.
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);
            EPSection config1 = ConfigurationManager.GetSection("EP") as EPSection;
            // Get the MyUrls section.
            EPSection myUrlsSection =
                config.GetSection("EP") as EPSection;
            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
