using System;
using System.Collections;
using System.Linq;

namespace DocumentMerger2 {
    class Program {
        static void Main(string[] args) {

            // check if arguments are provided
            if (args.Length > 0) {

                // check if there are at least 2 files and an output file name given as arguments
                if (args.Length < 3) {
                    Console.WriteLine("\nError: not enough documents provided to merge");
                    Console.Write("- At least 2 must be specified\n");
                }
                else {

                    // init Doc object list
                    ArrayList docs = new ArrayList();

                    // init array excluding the output file argument
                    var inputs = (string[])args.Take(args.Length - 1).ToArray();

                    // add new Doc object for each argument
                    foreach (string i in inputs) {
                        docs.Add(new Doc(i));
                    }

                    // init Merger object
                    Merger merge = new Merger(args[args.Length - 1], docs);

                    // merge files - writing to the specified output file
                    merge.Write();

                }
        
            }
            else {
                Console.WriteLine("Error: no arguments specified");
            }

        }
    }
}
