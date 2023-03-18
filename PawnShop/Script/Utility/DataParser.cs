﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PawnShop.Script.Utility
{
    /// <summary>
    /// Generic static utility class <c>DataParser</c> reads from a specified CSV file path.
    /// </summary>
    /// <typeparam name="T">The generic type of data structure each record is parsed into.</typeparam>
    public static class DataParser<T>
    {
        /// <summary>
        /// Static method <c>Parse</c> generates a list of the parsed record generated from reading CSV.
        /// </summary>
        /// <remarks>
        /// First line from CSV file will be ignored. Use this to annotate column headers. Last line <c>"\n"</c> auto-generated by CSV will also be ignored.
        /// </remarks>
        /// <param name="dir"> String: absolute path to the file.</param>
        /// <param name="file"> String: filename.</param>
        /// <param name="parser"> Function delegate: accepts a string representing the record being parsed and returning the generic record type <typeparamref name="T"/>. In a CSV, this refers to an entire line.</param>
        /// <returns>
        /// A <c>List</c> of the <typeparamref name="T"/> type provided.
        /// </returns>
        public static List<T> Parse(string dir, string file, Func<string, T> parser)
        {
            StreamReader reader = new StreamReader($"{dir}\\{file}");
            string[] lines = reader.ReadToEnd().Split('\n');
            List<T> result = new List<T>();
            for (int i = 1; i < lines.Length - 1; i++)
            {
                result.Add(parser(lines[i].Trim()));
            }
            reader.Close();
            return result;
        }
    }
}
