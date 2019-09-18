using System;
using System.Collections;
using System.Text.RegularExpressions;
// using System.Linq;

namespace DocumentMerger {
    class Program {
        static void Emphasize(string t, bool space = true) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (space) Console.WriteLine("\n{0}\n", t);
            else Console.Write(t);
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
                Emphasize("> Would you like to add another file? : ", false);
            } while (Regex.IsMatch(Console.ReadLine(), @"^[Yy]"));

            // default file name
            string defName = "";

            // print each document for user review
            Emphasize("Files to be merged:");
            foreach (Doc f in files) {
                // print all lines of file
                f.PrintFile();
                // add name to the string
                defName += f.GetCleanName();
            }

            // append file extension to default file name
            defName += ".txt";
            // ask user for different name to save file
            Emphasize("\nName your file? (default: " + defName + "): ", false);
            string resp = Console.ReadLine();
            
            // concat all files content
            if (resp == "") {
                // write to default file name
                Merger m = new Merger(defName, files);
                m.Write();
            } else {
                // append .txt extension if not provided
                if (!Regex.IsMatch(resp, @"\.(...)")) {
                    resp += ".txt";
                }
                // write to given file name
                Merger m = new Merger(resp, files);
                m.Write();
            }
            
        }
    }
}
