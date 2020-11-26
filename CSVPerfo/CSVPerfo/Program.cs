using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace CSVPerfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string path = "..\\..\\..\\..\\Dataset\\cars.csv";
            string[] lines = File.ReadAllLines(path);
            //RemoveDuplicates(lines);

            foreach (string country in Countrylister(lines))
            {
                Console.WriteLine(GetLightestCarAndBiggestCylindersByCountry(lines, country));
            }
            stopWatch.Stop();
            Console.WriteLine("L'opération a été effectué en {0} secondes", stopWatch.Elapsed.TotalSeconds);
        }

        private static List<string> GetCarsFromCountry(string[] lines, string origin)
        {
            List<string> carsFromCountry = new List<string>();
            foreach (string line in lines)
            {
                if (line.Split(',')[8].Equals(origin)) carsFromCountry.Add(line);
            }
            return carsFromCountry;
        }

        private static float GetLowestFromArg(List<string> lines, int arg)
        {
            float res = 100000000f;
            foreach (string line in lines)
            {
                //On évite les données pourries
                if (float.Parse(line.Split(',')[arg], CultureInfo.InvariantCulture.NumberFormat) != 0)
                {
                    if (float.Parse(line.Split(',')[arg], CultureInfo.InvariantCulture.NumberFormat) < res) res = float.Parse(line.Split(',')[arg], CultureInfo.InvariantCulture.NumberFormat);
                }
            }
            return res;
        }

        private static int GetBiggestFromArg(List<string> lines, int arg)
        {
            int res = 0;
            foreach (string line in lines)
            {
                //On évite les données pourries
                if (int.Parse(line.Split(',')[arg], CultureInfo.InvariantCulture.NumberFormat) != 0)
                {
                    if (int.Parse(line.Split(',')[arg], CultureInfo.InvariantCulture.NumberFormat) > res) res = int.Parse(line.Split(',')[arg], CultureInfo.InvariantCulture.NumberFormat);
                }
            }
            return res;
        }

        private static string GetLightestCarAndBiggestCylindersByCountry(string[] lines, string origin)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var carsFromCountry = GetCarsFromCountry(lines, origin);
            int maxCylinder = GetBiggestFromArg(carsFromCountry, 2);
            List<string> biggestCylindersFromCountry = new List<string>();
            foreach (string line in carsFromCountry)
            {
                if (int.Parse(line.Split(',')[2]) == maxCylinder) biggestCylindersFromCountry.Add(line);
            }
            int minimumWeight = (int)GetLowestFromArg(biggestCylindersFromCountry, 5);
            string res = "";
            foreach (string line in biggestCylindersFromCountry)
            {
                if (int.Parse(line.Split(',')[5]) == minimumWeight) res = line;
            }
            stopWatch.Stop();
            Console.WriteLine("La plus légère grosse cylindrée ayant pour origine : {0} a été trouvé en {1} secondes", origin, stopWatch.Elapsed.TotalSeconds);
            return res;
        }

        private static List<string> Countrylister(string[] lines)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            List<string> res = new List<string>();
            int index = 1;
            while (index < lines.Length)
            {
                var columns = lines[index].Split(',');
                if (!res.Contains(columns[8])) res.Add(columns[8]);
                index++;
            }
            stopWatch.Stop();
            Console.WriteLine("Tous les pays d'origine ont été trouvés en {0} secondes", stopWatch.Elapsed.TotalSeconds);
            return res;
        }

        private static void RemoveDuplicates(string[] lines)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            List<string> visited = new List<string>();
            foreach(string line in lines)
            {
                if (!visited.Contains(line)) visited.Add(line);
            }
            string path = "C:\\Users\\petit\\OneDrive\\Bureau\\Nouveau dossier (2)\\noDuplicateFS.csv";
            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist");
                using ( StreamWriter sw = File.CreateText(path))
                {
                    foreach (string line in visited)
                    {
                        sw.WriteLine(line);
                        sw.Flush();
                    }
                    sw.Close();
                }
            }
            stopWatch.Stop();
            Console.WriteLine("Tous les doublons ont été supprimés en {0} secondes", stopWatch.Elapsed.TotalSeconds);
        }
    }
}

