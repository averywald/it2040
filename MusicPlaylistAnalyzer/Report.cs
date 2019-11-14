using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Report {
    private string outputFile;
    private List<Song> songs;

    public Report(List<Song> p, string o) {
        this.songs = p;

        if (o.Contains(".txt")) this.outputFile = o;
        else this.outputFile = o + ".txt";

        // this.Export(this.outputFile);
        foreach (var i in linq(p)) {
            foreach (var x in i) {
                Console.WriteLine(x);
            }
        }
    }

    // return array of LINQ query outputs ???
    static List<IEnumerable<Dictionary<string, string>>> linq(List<Song> songs) {
        // initialize list to hold LINQ query results
        var queries = new List<IEnumerable<Dictionary<string, string>>>();

        // How many songs received 200 or more plays?
        queries.Add(songs.OrderBy(s => s.GetInfo()["Name"]).Where(s => Int32.Parse(s.GetInfo()["Plays"]) >= 200).Select(s => s.GetInfo()));
        // How many songs are in the playlist with the Genre of “Alternative”?
        queries.Add(songs.OrderBy(s => s.GetInfo()["Name"]).Where(s => s.GetInfo()["Genre"] == "Alternative").Select(s => s.GetInfo()));
        // How many songs are in the playlist with the Genre of “Hip-Hop/Rap”?
        queries.Add(songs.OrderBy(s => s.GetInfo()["Name"]).Where(s => s.GetInfo()["Genre"] == "Hip-Hop/Rap").Select(s => s.GetInfo()));
        // What songs are in the playlist from the album “Welcome to the Fishbowl?”
        queries.Add(songs.OrderBy(s => s.GetInfo()["Name"]).Where(s => s.GetInfo()["Album"] == "Welcome to the Fishbowl").Select(s => s.GetInfo()));
        // What are the songs in the playlist from before 1970?
        queries.Add(songs.OrderBy(s => s.GetInfo()["Name"]).Where(s => Int32.Parse(s.GetInfo()["Year"]) < 1970).Select(s => s.GetInfo()));
        // What are the song names that are more than 85 characters long?
        queries.Add(songs.OrderBy(s => s.GetInfo()["Name"]).Where(s => s.GetInfo()["Name"].Count() > 85).Select(s => s.GetInfo()));
        // What is the longest song? (longest in Time)
        // queries.Add(songs.Select(s => s.GetInfo()).Max(s => Int32.Parse(s.GetInfo()["Time"])));

        return queries;
    }

    // format LINQ results into txt file and export to filename
    public void Export(List<IEnumerable<Dictionary<string, string>>> q, string f) {
        // clean format????

        // export to filename
        using (var sw = new StreamWriter(f)) {
            try {

            }
            catch (Exception e) {
                throw e;
            }
            finally {
                sw.Close();
            }
        }
    }
}