using System.Collections.Generic;

class Song {
    private Dictionary<string, string> info = new Dictionary<string, string>();

    public Song(string[] data, string[] headers) {
        if (data.Length == headers.Length) {
            for (int i = 0; i < headers.Length; i++) {
                info.Add(headers[i], data[i]);
            }
        }
    }

    // return clone of info dict to keep immutability
    public Dictionary<string, string> GetInfo() {
        return new Dictionary<string, string>(this.info);
    }
}