using System;
using System.IO;
using System.Collections.Generic;

class Doc {
    string name;
    List<string> content;

    public Doc(bool prompt = true, string n = null, List<string> c = null) {
        if (prompt) {
            this.name = HandleInput();
            this.content = ReadFile(this.name);
        } else {
            this.name = n;
            this.content = c;
        }
    }

    public string GetName() {
        return this.name;
    }

    public List<string> GetContent() {
        return this.content;
    }

    public void PrintFile() {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("'{0}':", this.GetName());
        foreach (string line in this.content) {
            Console.WriteLine(line);
        }
        Console.ResetColor();
    }

    static string HandleInput() {

        // string to hold user input
        string input;

        // check if user entered anything
        do {
            Console.Write("> Specify a file to merge: ");
            // get user input
            input = Console.ReadLine();
        } while (String.IsNullOrEmpty(input));

        // check if file exists
        if (!File.Exists(Path.GetFullPath(input))) {
            // print error message
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!! File '{0}' does not exist !!", input);
            Console.ResetColor();
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
        }
        catch (Exception e) {
            // print error occurence to the console
            Console.WriteLine(e);
        }
        finally {
            // close StreamReader
            if (sr != null) sr.Close();
        }

        // return list of file lines
        return fileList;

    }
}