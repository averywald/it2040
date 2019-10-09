using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

class Merger {
    List<string> content = new List<string>();
    string name { get; set; }

    // call base constructor - Doc(false) to negate HandleInput() call
    public Merger(string n, ArrayList files) {
        
        foreach (Doc f in files) {
            foreach (string line in f.GetContent()) {
                this.content.Add(line);
            }
        }

        this.name = n;
        
    }

    // gets character count after merged doc has been saved
    int CharCount() {
        StreamReader sr = new StreamReader(this.name);
        return sr.ReadToEnd().ToCharArray().Length;
    }

    // writes the merged doc to the pwd
    public void Write() {

        StreamWriter sw = new StreamWriter(this.name);

        try {
            // writes line by line
            foreach (string line in this.content) {
                sw.WriteLine(line);
            }
        } catch (Exception e) {
            Console.WriteLine(e);
        } finally {
            // if streamwriter references something
            if (sw != null) {
                // close stream
                sw.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                // success message
                Console.WriteLine(this.name + " was successfully saved !!");
                Console.WriteLine("The document contains {0} characters", this.CharCount());
                Console.ResetColor();
            } else {
                // dump the stream
                sw.Dispose();
                Console.ForegroundColor = ConsoleColor.Red;
                // error message
                Console.WriteLine(this.name + " could not be saved !!");
                Console.ResetColor();
            }
        }
        
    }
}