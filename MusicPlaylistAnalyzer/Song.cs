using System;

class Song {
    // store all the information for each simply
    // make easily iterable for LINQ parsing

    String name { get; set; }
    String artist { get; set; }
    String album { get; set; }
    String genre { get; set; }

    // helper function for converting string to int
    int Convert(string n) {
        // will return 0 if it fails
        Int32.TryParse(n, out int x);
        return x;
    }

    int size {
        get { return size; }
        set { this.size = Convert(value.ToString()); }
    }
    int time {
        get { return time; }
        set { this.time = Convert(value.ToString()); }
    }
    int year {
        get { return year; }
        set { this.year =Convert(value.ToString()); }
    }
    int plays {
        get { return plays; }
        set { this.plays = Convert(value.ToString()); }
    }

    // name artist album genre size time year plays
    public Song(string[] data, int headerCount) {
        foreach (var d in data) {
            Console.WriteLine(d);
        }
    }

    // override public string ToString() {
    //     return String.Format(
    //         "Name: {0}\nArtist: {1}\nAlbum: {2}\nGenre: {3}\nSize: {4}\nTime: {5}\nYear: {6}\nPlays: {7}",
            
    //     );
    // }
}