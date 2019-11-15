using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Report {
    private string outputFile;
    private List<Song> songs;

    public Report(List<Song> p, string o) {
        // pass in Song objects
        this.songs = p;
        // check for file extension
        if (o.Contains(".txt")) this.outputFile = o;
        else this.outputFile = o + ".txt";
        // create report doc and export file
        Export(linq(this.songs), this.outputFile);
        
    }

    // return array of LINQ query outputs ???

    // TODO: get LINQ result count for each query
    static Dictionary<string, IEnumerable<Dictionary<string, string>>> linq(List<Song> songs) {
        // initialize list to hold LINQ query results
        var queries = new Dictionary<string, IEnumerable<Dictionary<string, string>>>();

        // How many songs received 200 or more plays?
        queries.Add("\nSongs with 200 or more plays:\n",
            songs.OrderBy(s => s.GetInfo()["Name"]).Where(s => Int32.Parse(s.GetInfo()["Plays"]) >= 200).Select(s => s.GetInfo()));
        // How many songs are in the playlist with the Genre of “Alternative”?
        queries.Add("\nAlternative Songs:\n",
            songs.OrderBy(s => s.GetInfo()["Name"]).Where(s => s.GetInfo()["Genre"] == "Alternative").Select(s => s.GetInfo()));
        // How many songs are in the playlist with the Genre of “Hip-Hop/Rap”?
        queries.Add("\nHip-Hop/Rap Songs:\n",
            songs.OrderBy(s => s.GetInfo()["Name"]).Where(s => s.GetInfo()["Genre"] == "Hip-Hop/Rap").Select(s => s.GetInfo()));
        // What songs are in the playlist from the album “Welcome to the Fishbowl?”
        queries.Add("\nSongs from 'Welcome to the Fishbowl':\n",
            songs.OrderBy(s => s.GetInfo()["Name"]).Where(s => s.GetInfo()["Album"] == "Welcome to the Fishbowl").Select(s => s.GetInfo()));
        // What are the songs in the playlist from before 1970?
        queries.Add("\nSongs made before 1970:\n",
            songs.OrderBy(s => s.GetInfo()["Name"]).Where(s => Int32.Parse(s.GetInfo()["Year"]) < 1970).Select(s => s.GetInfo()));
        // What are the song names that are more than 85 characters long?
        queries.Add("\nSongs with Titles longer than 85 characters:\n",
            songs.OrderBy(s => s.GetInfo()["Name"]).Where(s => s.GetInfo()["Name"].Count() > 85).Select(s => s.GetInfo()));
        // What is the longest song? (longest in Time)
        // get max value
        var max = songs.Max(s => Int32.Parse(s.GetInfo()["Time"]));
        Console.WriteLine(max);
        // get Song obj data matching max value
        var q = songs.First(s => Int32.Parse(s.GetInfo()["Time"]) == max).GetInfo();
        foreach (var i in q) { Console.WriteLine(i); }
        // create wrapper IEnum to hold the Song data Dict
        IEnumerable<Dictionary<string, string>> wrapper = new List<Dictionary<string, string>>();
        // add data to wrapper
        wrapper.Append(q);
        // add wrapper IEnum to returnable list
        queries.Add("\nLongest song in the Playlist:\n", wrapper);

        return queries;
    }

    // format LINQ results into txt file and export to filename
    public void Export(Dictionary<string, IEnumerable<Dictionary<string, string>>> q, string f) {
        // clean format????
        // for (int i = 0; i < q.Count; i++) {
        //     var x = q.ElementAt(i);
        //     Console.WriteLine(x.Key);
        //     foreach (var y in x.Value) {
        //         foreach (var z in y)
        //         {
        //             Console.WriteLine(z);
        //         }
        //     }
        // }


        // export to filename
        // using (var sw = new StreamWriter(f)) {
        //     try {

        //     }
        //     catch (Exception e) {
        //         throw e;
        //     }
        //     finally {
        //         sw.Close();
        //     }
        // }
    }
}