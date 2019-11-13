using System;
using System.IO;

namespace MusicPlaylistAnalyzer {
    class Program {
        static void Main(string[] args) {

            // check for extra arguments
            if (args.Length > 1) {
                Console.WriteLine("\nYou entered at least one extra argument, which is fine, but won't do anything");
            }

            using (var sr = new StreamReader("SampleMusicPlaylist.txt")) {
                try {
                    // get number of headers
                    var headers = sr.ReadLine().Split('\t').Length;

                    // init playlist to collect song objs
                    Playlist p = new Playlist();

                    // read in rest of file
                    // while (!sr.EndOfStream) {
                        // read lines into playlist obj of song objects
                        // split values by tabs
                        var values = sr.ReadLine().Split('\t');

                        // add data to song obj
                        var s = new Song(values, headers);
                        
                    // }
                    
                } catch (Exception e) {
                    Console.WriteLine("\nThe following error has occurred:\n{0}", e);

                    // Playlist data file can’t be opened.
                    if (e is FileNotFoundException) {
                        
                    }
                    
                    // Error occurs reading lines from playlist data file.
                    

                    // Record doesn’t contain the correct number of data elements.
                    // Record contains data that is not of the right type.Note: Some data elements are strings and some are integers.
                    // Report file can’t be opened or written to.

                    // $"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}."

                } finally { sr.Close(); }
            }
            
            // check for output file argument
            string outputFile = "Default.txt";
            if (args.Length >= 1) outputFile = args[0];

            // generate report
            // var r = new Report(p, outputFile);
        }
    }
}
