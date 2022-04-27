// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Dictionary<string, HashSet<string>> table = new Dictionary<string, HashSet<string>>();
using (StreamReader reader = new StreamReader(@"E:\Artical.tsv"))
{
    var line = reader.ReadLine();
    while (line != null)
    {
        var items = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
        var ids = items[3].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        table[items[0]] = new HashSet<string>(ids);
        line = reader.ReadLine();
    }
}

List<string> topics = new List<string>() { "msn_headlines", "msn_uk", "msn_world", "msn_food_video", "msn_politics" };
foreach (var item in table)
{
    if (topics.Contains(item.Key))
    {
        table["msn_news"].ExceptWith(item.Value);
    }
}
