using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Ini;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IniConfigurationSource source = new IniConfigurationSource();
            source.Path = @"E:\demo.txt";
            source.ReloadOnChange = true;
            source.Optional = false;
            ConfigurationBuilder builer = new ConfigurationBuilder();
            builer.Add(source);
            var  ss = builer.Build();
            var provider = source.Build(builer);
            provider.Load();
            ///  var config = IniConfigurationExtensions.AddIniFile(@"C:\Users\Neusoft\Downloads\20220216-enstar-demotion-revision\demo.txt");
            Console.Read();
        }
    }
}
