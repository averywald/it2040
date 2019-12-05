using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MusicPlaylistAnalyzer {
    class Program {
        static void Main(string[] args) {

            // container for CLI arguments
            List<string> inputs = new List<string>();
            // check for extra arguments
            if (args.Length > 1) {
                // start at extra arguments
               for (int i = 1; i < args.Length; i++) {
                   // push args to input list
                   inputs.Add(args[i]);
               }
            }

            // collect songs
            List<Song> songs = new List<Song>();

            // read in data file
            using (var sr = new StreamReader(args[0])) {

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


            // default output file name
            string outputFile = "default.txt";
            // check for output file name argument
            if (args.Length > 1) {
                // use output file argument if provided
                outputFile = args[2];
            } else {
                // prompt user to name their output file
                Console.WriteLine("\nSpecify the name of your output file (default: 'default.txt')");
                // store input
                string input = Console.ReadLine();
                // if user skips naming
                if (input.Length != 0) {
                    // keep default file name
                    outputFile = input;
                }
            }

            // generate report
            var r = new Report(songs, outputFile);
        }
    }
}
