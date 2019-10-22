using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// TO DO
// stream reader csv exception handling
// LINQ query implementation
// output report file implementation

namespace CrimeAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            // check for correct arguments
            if (args.Length > 0)
            {
                // list for crime stat instances per year
                ArrayList data = new ArrayList();

                // create new read stream of file in run command
                using (var reader = new StreamReader(args[0]))
                {
                    // read first line (CSV header line)
                    var l = reader.ReadLine();
                    // separate values within line into array
                    String[] headers = l.Split(',');

                    // read in whole file
                    while (!reader.EndOfStream)
                    {
                        // read line of data per year
                        var line = reader.ReadLine();
                        // convert parsed data fields from string to int
                        int[] converted = Array.ConvertAll(line.Split(','), element =>
                        {
                            return int.Parse(element);
                        });
                        // add separate values into a CrimeStats instance
                        data.Add(new CrimeStats(headers, converted));
                    }

                    reader.Close();
                }

                // init report obj for output
                Report report = new Report(data);
            } 
            else
            {
                Console.WriteLine("Error: Arguments expected");
            }
        }
    }
}
