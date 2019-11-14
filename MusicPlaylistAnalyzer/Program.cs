using System;
using System.IO;
using System.Collections.Generic;

namespace MusicPlaylistAnalyzer {
    class Program {
        static void Main(string[] args) {

            // check for extra arguments
            if (args.Length > 1) {
                Console.WriteLine("\nYou entered at least one extra argument, which is fine, but won't do anything");
            }

            // collect songs
            List<Song> songs = new List<Song>();

            using (var sr = new StreamReader("SampleMusicPlaylist.txt")) {

                try {

                    // get number of headers
                    var l = sr.ReadLine();
                    var headers = l.Split('\t');
                    int headerCount = headers.Length;

                    // read in rest of file
                    do {
                        // read in each line's values
                        var line = sr.ReadLine();
                        var values = line.Split('\t');
                        // add data to song obj
                        var s = new Song(values, headers);
                        // add song obj to playlist
                        songs.Add(s);
                    } while (!sr.EndOfStream);

                } catch (Exception e) {

                    throw e;
                    
                    // Error occurs reading lines from playlist data file.
                    
                    // Record doesn’t contain the correct number of data elements.
                    // Record contains data that is not of the right type.Note: Some data elements are strings and some are integers.
                    // Report file can’t be opened or written to.

                    // $"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}."

                } finally { sr.Close(); }

            }

            // Console.WriteLine(songs.songs);

            // check for output file argument
            string outputFile = "default.txt";
            if (args.Length >= 1) outputFile = args[0];

            foreach (var i in songs[10].GetInfo()) {
                Console.WriteLine(i);
            }

            // generate report
            // var r = new Report(songs, outputFile);
        }
    }
}
