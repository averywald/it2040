using System;
using System.Collections.Generic;

class CrimeStats
{
    IDictionary<string, int> stats = new Dictionary<string, int>();

    public CrimeStats(string[] headers, int[] data)
    {
        // check if data for every header
        if (headers.Length == data.Length)
        {
            for (int i = 0; i < headers.Length; i++)
            {
                // add each key-value pair to stats dictionary
                this.stats.Add(new KeyValuePair<string, int>(headers[i], data[i]));
            }
        } 
        else 
        {
            Console.WriteLine("Error: Missing or extra data / headers");
        }
    }

    public IDictionary<string, int> GetStats()
    {
        return this.stats;
    }

    public int GetYear()
    {
        return this.stats["Year"];
    }

    public int Query(string key)
    {
        return this.stats[key];
    }
}