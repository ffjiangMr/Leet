using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ini
{
    public sealed class IniSection
    {
        private String name;

        private Dictionary<String, String> items;

        public String Name { get { return this.name; } }

        public IniSection(string sectionName)
        {
            this.name = sectionName;
            this.items = new Dictionary<String, String>();
        }

        public ICollection<String> Keys
        {
            get
            {
                return this.items?.Keys;
            }
        }

        public String GetValue(String key)
        {
            String result = String.Empty;

            if ((this.items != null) && (this.items.ContainsKey(key) == true))
            {
                result = this.items[key];
            }

            return result;
        }

        public Boolean AddParams(String key, String value)
        {
            Boolean result = false;
            if ((this.items != null) && (this.items.ContainsKey(key) == false))
            {
                this.items[key] = value;
            }
            return result;
        }
    }

    public sealed class IniHelper
    {
        public List<String> SourcePath { get; set; }

        private Dictionary<String, IniSection> buffer;

        public IniHelper()
        {
            this.buffer = new Dictionary<String, IniSection>();
        }

        public IniHelper(List<String> source)
            : this()
        {
            this.SourcePath = source;
        }

        public ICollection<String> SectionNames { get { return this.buffer.Keys; } }

        public IniSection GetSection(String name)
        {
            IniSection section = null;
            if (this.buffer.ContainsKey(name) == true)
            {
                section = this.buffer[name];
            }
            return section;
        }


        public Boolean Load()
        {
            Boolean result = false;
            if (this.SourcePath != null)
            {
                foreach (var path in this.SourcePath)
                {
                    if (File.Exists(path) == true)
                    {
                        using (var reader = new StreamReader(path))
                        {
                            String line = reader.ReadLine()?.Trim();
                            IniSection section = null;
                            while (line != null)
                            {
                                if (String.IsNullOrWhiteSpace(line) == false)
                                {
                                    var content = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[0];
                                    if (content.StartsWith("["))
                                    {
                                        this.CreateSection(ref section, content.Substring(1, content.Length - 2).Trim());
                                    }
                                    else
                                    {
                                        var item = content.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                                        if ((item.Length == 2))
                                        {
                                            this.CreateParams(ref section, item[0], item[1]);
                                        }
                                    }
                                }
                                line = reader.ReadLine()?.Trim();
                            }
                        }
                    }
                    else
                    {
                        /// ToDo exception handling 
                    }
                }
            }
            return result;
        }

        private void CreateSection(ref IniSection section, String name)
        {
            if (this.buffer.ContainsKey(name) == true)
            {
                section = this.buffer[name];
            }
            else
            {
                section = new IniSection(name);
                this.buffer[name] = section;
            }
        }

        private void CreateParams(ref IniSection section, String key, String value)
        {
            if (section == null)
            {
                this.CreateSection(ref section, "Def_Sec");
            }
            section.AddParams(key, value);
        }
    }

}
