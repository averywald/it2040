using System;
using System.IO;
using System.Collections.Generic;

namespace DocumentMerger {
    class Program {

        static string HandleInput() {

            // string to hold user input
            string input;

            do {
                // get user input
                Console.Write("Specify a file to merge: ");
                input = Console.ReadLine();
            } while (String.IsNullOrEmpty(input));

            // check if file exists
            if (!File.Exists(Path.GetFullPath(input))) {
                // print error message
                Console.WriteLine("File '{0}' does not exist !!", input);
                // recursion to redo the loop
                input = HandleInput();
            }
            
            return input;

        }

        static List<string> ReadFile(string f) {

            // initialize list to dynamically add text lines to
            List<string> fileList = new List<string>();
            // create StreamReader to read specified file
            StreamReader sr = new StreamReader(f);

            try {
                // read in first line
                string line = sr.ReadLine();
                // read in the rest of the file line by line
                while (line != null) {
                    // write line
                    fileList.Add(line);
                    // read next line
                    line = sr.ReadLine();
                }
            } catch (Exception e) {
                // print error occurence to the console
                Console.WriteLine(e);
            } finally {
                // close StreamReader
                if (sr != null) sr.Close();
            }

            // return list of file lines
            return fileList;

        }

        static void Main(string[] args) {

            Console.WriteLine("\nDocument Merger\n");
            
            List<string> f = ReadFile(HandleInput());

            foreach (string line in f) {
                Console.WriteLine(line);
            }

        }
    }
}
