using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            String 
            InitializeComponent();
            List<string> list = new List<string>();
            list.AddRange(new string[] { "ASP.NET课程", "J2EE课程", "PHP课程", "数据结构课程" });
            ///Predicate<string> findPredicate = new Predicate<string>(IsBookCategory);
            List<string> bookCategory = list.FindAll(item => { return item.StartsWith(""); });
            foreach (string str in bookCategory)
            {
                Console.WriteLine("{0}\t", str);
            }
        }
    }
}
