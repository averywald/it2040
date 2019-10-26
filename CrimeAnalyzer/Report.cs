using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;

class Report
{
    // imported CrimeStats objects
    ArrayList data;

    public Report(ArrayList data)
    {
        // import CrimeStats objects
        this.data = data;
    }

    public ArrayList GetData()
    {
        return this.data;
    }

    private int[] GetMurders()
    {
        // LINQ query
        IEnumerable<int> mq = from CrimeStats d in this.data
                                where d.GetStats()["Murder"] < 15000
                                select d.GetStats()["Year"];
        return mq.ToArray();
    }

    private Dictionary<int, string> GetRange()
    {
        // LINQ query for years in csv
        IEnumerable<int> rangeQuery = from CrimeStats d in this.data
                                  select d.GetStats()["Year"];
        // put years into integer array for parsing
        int[] years = rangeQuery.ToArray();
        // get range difference
        int range = years[years.Length - 1] - years[0];
        // pass range endcaps to string
        string rs = years[0] + " - " + years[years.Length - 1];
        // return range difference and specific years
        return new Dictionary<int, string>() {
            { range, rs }
        };
    }

    private Dictionary<int, int> GetRobberies()
    {
        IEnumerable<IDictionary<string, int>> q = from CrimeStats d in this.data
                            where d.GetStats()["Robbery"] > 500000
                            select d.GetStats();
    
        var robberies = new Dictionary<int, int>();

        foreach (IDictionary<string, int> i in q)
        {
            robberies.Add(i["Year"], i["Robbery"]);
        }

        return robberies;
    }

    private decimal GetVC()
    {
        IEnumerable<IDictionary<string, int>> q = from CrimeStats d in this.data
                                                  where d.GetStats()["Year"] == 2010
                                                  select d.GetStats();
        var x = q.First();
        return (decimal)x["Violent Crime"] / (decimal)x["Population"];
    }

    private decimal GetAvgMurders()
    {
        var q = from CrimeStats d in this.data
                    select d.GetStats();
        decimal avg = 0;
        int count = 0;
        foreach (var item in q)
        {
            avg += item["Murder"];
            count++;
        }
        return avg / count;
    }

    private decimal MurderRange1()
    {
        var q = from CrimeStats d in this.data
                where d.GetStats()["Year"] <= 1997
                select d.GetStats()["Murder"];
        decimal avg = 0;
        int count = 0;
        foreach (var item in q)
        {
            avg += item;
            count++;
        }
        return avg / count;
    }

    private decimal MurderRange2()
    {
        var q = from CrimeStats d in this.data
                where d.GetStats()["Year"] >=  2010
                where d.GetStats()["Year"] <= 2013
                select d.GetStats()["Murder"];
        decimal avg = 0;
        int count = 0;
        foreach (var item in q)
        {
            avg += item;
            count++;
        }
        return avg / count;
    }

    private double Theft(string mode = "min")
    {
        if (mode == "min")
        {
            var q = from CrimeStats d in this.data
                    where d.GetStats()["Year"] >= 1999
                    where d.GetStats()["Year"] <= 2004
                    select d.GetStats()["Theft"];
            double min = q.Min();
            return min;
        }
        else {
            var q = from CrimeStats d in this.data
                    where d.GetStats()["Year"] >= 1999
                    where d.GetStats()["Year"] <= 2004
                    select d.GetStats()["Theft"];
            double max = q.Max();
            return max;
        }
        
    }

    // private int MVTheft()
    // {
    //     var q = (from CrimeStats d in this.data
    //             select new {
    //                 Year = d.GetStats()["Year"]
    //             });
    //     int year = 0;

    //     return year;

    // }

    public void Build(string outputPath)
    {
        // compile query outputs
        ArrayList queries = new ArrayList() {
            { "Crime Analyzer Report\n" },
            { "Period " + this.GetRange() + " (" + this.GetRange().Keys.ToString() + " years)" },
            { "Years murders per year < 15000: " + this.GetMurders().ToString() },
            { "Robberies per year > 500000: " + this.GetRobberies().ToString() },
            { "Violent crime per capita rate (2010): " + this.GetVC() },
            { "Average murder per year (all years): "  + this.GetAvgMurders() },
            { "Average murder per year (1994–1997): " + this.MurderRange1() },
            { "Average murder per year (2010–2014): " + this.MurderRange2() },
            { "Minimum thefts per year (1999–2004): " + this.Theft() },
            { "Maximum thefts per year (1999–2004): " + this.Theft("max") },
        };

        // write stream to outputPath
        var sw = new StreamWriter(outputPath);
        try    
        {
            using (sw)
            {
                foreach (string l in queries)
                {
                    sw.WriteLine(l);
                }
            }
        }
        catch {}
        finally { sw.Close(); }
    }
}