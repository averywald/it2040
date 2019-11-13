using System.Collections.Generic;
class Playlist {

    List<Song> songs {
        get { return songs; }
        set {}
    }
    public Playlist() {
        // init Song List
        this.songs = new List<Song>();
    }

    public void Add(Song s) {
        this.songs.Add(s);
    }

}