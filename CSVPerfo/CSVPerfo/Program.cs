using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSVPerfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "..\\..\\..\\..\\Dataset\\cars.csv";
            string[] lines = System.IO.File.ReadAllLines(path);


            //foreach(string country in Countrylister(lines))
            //{
            //    Console.WriteLine(country);
            //    Console.WriteLine(getLightestCarAndBiggestCylindersByCountry(lines, country));
            //}


            Console.WriteLine(getLightestCarAndBiggestCylindersByCountry(lines, "Europe"));


        }

        private static string getLightestCarAndBiggestCylindersByCountry(string[] lines, string origin)
        {
            string res = "";
            foreach (string line in lines)
            {
                var columns = line.Split(',');

                if (res == "")
                {
                    Console.WriteLine(line);
                    if (line.Contains(origin)) res = line;
                    //if (columns[8].) res = line;
                }
                else
                {
                    if (Int32.Parse(columns[2]) >= Int32.Parse(res.Split(',')[2]) && Int32.Parse(columns[5]) < Int32.Parse(res.Split(',')[5])) res = line;
                }
            }
            return res;
        }

        private static List<String> Countrylister(string[] lines)
        {
            List<String> res = new List<string>();
            foreach (string line in lines.Skip(1))
            {
                var columns = line.Split(',');
                if (!res.Contains(columns[8])) res.Add(columns[8]);
            }
            return res;
        }
    }
}
