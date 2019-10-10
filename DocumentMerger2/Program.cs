using System;
using System.Collections;
using System.Linq;
using System.IO;

// TO DO:
// - exception handling when wrong input format
// - handle files not existing

namespace DocumentMerger2 {
    class Program {

        // check if the file arguments exist
        static void checkFile(string[] files) {

            // init arraylist to hold non-existent files
            ArrayList errors = new ArrayList();

            foreach (string f in files) {
                if (!File.Exists(f)) {
                    // add to list of non-existent files
                    errors.Add(f);
                }
            }

            // if non-existent files
            if (errors.Count > 0) {
                Console.WriteLine($"\nError: file(s):");
                // print each to console in error message
                foreach (string f in errors) {
                    Console.WriteLine($"{f}");
                }
                Console.WriteLine("does not exist");
                Console.WriteLine("Make sure the file path is correct\n");
                // terminate the program
                Environment.Exit(0);
            }

        }
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

                    // check existence of inputs
                    checkFile(inputs);

                    // add new Doc object for each argument
                    foreach (string i in inputs) {
                        // else add file to docs arraylist
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
