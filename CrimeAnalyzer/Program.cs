using System;
using System.IO;
using System.Collections;

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
                    try
                    {
                        // read first line (CSV header line)
                        var l = reader.ReadLine();
                        // separate values within line into array
                        String[] headers = l.Split(',');
                        // line counter
                        int count = 1;

                        // read in whole file
                        while (!reader.EndOfStream)
                        {
                            // read line of data per year
                            var line = reader.ReadLine();
                            // increment line counter
                            count++;
                            // convert parsed data fields from string to int
                            int[] converted = Array.ConvertAll(line.Split(','), element =>
                            {
                                return int.Parse(element);
                            });
                            // check for missing data and omit line if so
                            if (converted.Length != headers.Length)
                            {
                                Console.WriteLine(
                                    "Error: Row {0} has {1} values when it should have {2}", 
                                    count, converted.Length, headers.Length
                                );
                            }
                            else {
                                // add separate values into a CrimeStats instance
                                data.Add(new CrimeStats(headers, converted));
                            }
                        }
                    }
                    catch (FileNotFoundException f) { throw f; }
                    catch (IOException i) { throw i; }
                    catch (Exception e) { throw e; }
                    finally { reader.Close(); }
                } 
            
                // init report obj for output
                Report report = new Report(data);
                // output report to specified filename
                report.Build(args[1]);
            } 
            else
            {
                Console.WriteLine("Error: Arguments expected");
            }
        }
    }
}
