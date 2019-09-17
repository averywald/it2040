using System;
using System.Collections;
using System.Text.RegularExpressions;
// using System.Linq;

namespace DocumentMerger {
    class Program {
        static void Emphasize(string t, bool space = true) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (space) Console.WriteLine("\n{0}\n", t);
            else Console.WriteLine(t);
            Console.ResetColor();
        }
        static void Main(string[] args) {

            Emphasize("Document Merger");

            // holds dynamic amount of Doc objects
            ArrayList files = new ArrayList();

            // loop to continuously add files to be merged
            do {
                // read in new file
                Doc f = new Doc();
                // add to list of files to be merged
                files.Add(f);

                // do something

                // ask user if they want to merge another file
                Console.Write("> Would you like to add another file? : ");
            } while (Regex.IsMatch(Console.ReadLine(), @"^[Yy]"));

            // holds all the file names
            ArrayList names = new ArrayList();

            // print each document for user review
            Emphasize("Files to be merged:");
            foreach (Doc f in files) {
                // print all lines of file
                f.PrintFile();
                // add name to the arraylist
                names.Add(f.GetName());
            }

            // handle saving the newly merged file
                // strip file extensions
                // concat
                // append .txt

                // concat all files content
                    // new class ???
                // save new file to current dir
        }
    }
}
