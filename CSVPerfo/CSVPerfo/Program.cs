using System;
using System.Collections.Generic;
using System.IO;

namespace CSVPerfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var reader = new StreamReader(@"..\..\..\..\Dataset\cars.csv"))
  
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    Console.WriteLine(line);

                    //listA.Add(values[0]);
                    //listB.Add(values[1]);
                }
            }
        }
    }
}
