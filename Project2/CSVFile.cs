using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    internal class CSVFile
    {
        public static List<string> CSVDeserialize(string filename)
        {
            List<string> result = new List<string>();
            string csvString = File.ReadAllText(@"..\..\..\Data\" + filename);
            string[] data = csvString.Split('\n');
            for(int i = 1; i < data.Length; i++)
            {
                result.Add(data[i].Split(',')[1].Trim());
            }
            return result;
        }
    }
}
