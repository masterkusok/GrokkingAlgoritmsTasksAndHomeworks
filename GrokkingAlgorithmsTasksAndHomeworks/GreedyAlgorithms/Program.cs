class Program
{
    public static void Main()
    {
        List<string> statesNeeded = new List<string>()
        {
            "mt", "wa", "or", "id", "nv", "ut", "ca", "az"
        };

        Dictionary<string, List<string>> stations = new Dictionary<string, List<string>>();
        stations.Add("kone", new List<string>() { "id", "nv", "ut" });
        stations.Add("ktwo", new List<string>() { "wa", "id", "mt" });
        stations.Add("kthree", new List<string>() { "or", "nv", "ca" });
        stations.Add("kfour", new List<string>() { "ut", "nv", });
        stations.Add("kfive", new List<string>() { "ca", "az" });

        List<string> finalStations = new List<string>();
        List<string> statesCovered = new List<string>();
        string bestStation = string.Empty;

        while (statesCovered.Count() != statesNeeded.Count())
        {
            foreach (var station in stations)
            {
                List<string> canCover = station.Value.Intersect(statesNeeded).ToList();
                if (canCover.Count() > statesCovered.Count())
                {
                    bestStation = station.Key;
                    statesCovered = canCover;
                }
            }
            statesNeeded = statesNeeded.Except(statesCovered).ToList();
            statesCovered.Clear();
            finalStations.Add(bestStation);
        }
        foreach(string station in finalStations)
        {
            Console.Write(station + " ");
        }
    }

}