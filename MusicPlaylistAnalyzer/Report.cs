using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Report {
    // build report and output to file

    private string outputFile;
    private List<Song> songs;

    public Report(List<Song> p, string o) {
        this.songs = p;

        if (o.Contains(".txt")) this.outputFile = o;
        else this.outputFile = o + ".txt";

        // generate LINQ output

        // this.Export(this.outputFile);
    }

    public void Export(string f) {
        using (var sw = new StreamWriter(f)) {
            try {

            } catch (Exception e) {
                throw e;
            } finally {
                sw.Close();
            }
        }
    }

    // How many songs received 200 or more plays?
    // How many songs are in the playlist with the Genre of “Alternative”?
    // How many songs are in the playlist with the Genre of “Hip-Hop/Rap”?
    // What songs are in the playlist from the album “Welcome to the Fishbowl?”
    // What are the songs in the playlist from before 1970?
    // What are the song names that are more than 85 characters long?
    // What is the longest song? (longest in Time)
}