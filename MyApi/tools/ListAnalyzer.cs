namespace MyApi.tools;

using System.Linq;

public class ListAnalyzer {

    public static bool hasDuplicates<T>(List<T> items)
    {
        return items.GroupBy(x => x).Any(global => global.Count() >1 );
    }

}