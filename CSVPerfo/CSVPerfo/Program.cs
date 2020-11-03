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
            List<string> carCountrys = new List<string>();
            List<string> biggestCylinderUsCars = new List<string>();
            List<string> lightestCars = new List<string>();

            var index = 0;
            foreach (string line in lines)
            {
                if (index > 0)
                {
                    var columns = line.Split(';');

                    int carCylinder = Int32.Parse(columns[2]);
                    var carCountry = columns[8];
                    int carWeight = Int32.Parse(columns[5]);

                    // Biggest US Cylinder car
                    if (carCountry == "US" && carCylinder == maxCylinder(lines, "US"))
                    {
                        biggestCylinderUsCars.Add(line);
                    }
       
                    if (!carCountrys.Contains(carCountry))
                    {
                        carCountrys.Add(carCountry);
                    }

                    foreach (string country in carCountrys)
                    {
                        if (carWeight == lightest(lines, country) && country == carCountry)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                index++;
            }

            Console.WriteLine("\nlist of biggest Cylinder US Car");
            foreach (string biggestCylinderUsCar in biggestCylinderUsCars)
            {
                Console.WriteLine(biggestCylinderUsCar);
            }

        }

        
        private static int maxCylinder(string[] lines, string country)
        {
            List<int> carCylinders = new List<int>();
            foreach (string line in lines)
            {
                var columns = line.Split(';');
                if (columns[8] == country)
                {
                    carCylinders.Add(Int32.Parse(columns[2]));
                }
            }
            int maxCarCylinder = carCylinders.Max();
            return maxCarCylinder;
        }

        private static int lightest(string[] lines, string country)
        {
            List<int> carWeights = new List<int>();
            foreach (string line in lines)
            {
                var columns = line.Split(';');
                if (columns[8] == country)
                {
                    int carWeight = Int32.Parse(columns[5]);
                    carWeights.Add(carWeight);
                }

            }
            int lightestCarWeight = carWeights.Min();
            return lightestCarWeight;
        }
    }
}
