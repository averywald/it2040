using System.Linq;
using System.Collections;
using System.IO;

class Report
{
    ArrayList data;
    // IDictionary<IEnumerable<int>> 
    
    // LINQ queries
    // IEnumerable<CrimeStats> query = from CrimeStats d in data
    //                                 where d.getStats()["Rape"] > 90000
    //                                 select d;
    // get year range
    // IEnumerable<int> rangeQuery = from CrimeStats d in data
    //                               select d.getStats()["Year"];

    public Report(ArrayList data)
    {
        this.data = data;
    }

    public void Build(string outputPath)
    {
        // compile query outputs
        // write stream to outputPath
    }
}