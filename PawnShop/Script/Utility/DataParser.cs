using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PawnShop.Script.Utility
{
    public static class DataParser<T>
    {
        public static List<T> Parse(string dir, string file, Func<string, T> parser)
        {
            StreamReader reader = new StreamReader($"{dir}\\{file}");
            string[] lines = reader.ReadToEnd().Split('\n');
            List<T> result = new List<T>();
            for (int i = 1; i < lines.Length; i++)
            {
                result.Add(parser(lines[i]));
            }
            reader.Close();
            return result;
        }
    }
}
