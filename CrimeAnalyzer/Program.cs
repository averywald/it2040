using System;
using System.IO;
using System.Collections;

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
                    int[] converted = Array.ConvertAll(line.Split(','), element => {
                        return int.Parse(element);
                    });

                    // add separate values into a CrimeStats instance
                    data.Add(new CrimeStats(headers, converted));
                }

                reader.Close();
            }

            // print data entries
            foreach (CrimeStats d in data)
            {
                Console.WriteLine("\n");

                var entry = d.getStats();

                foreach (var kvp in entry)
                {
                    var key = kvp.Key;
                    var val = kvp.Value;
                    Console.WriteLine("{0}: {1}", key, val);
                }
            }
        }
    }
}
