class Program
{
    /*
     Graph from example looks like this
        A
     6/ | \1
     /  |  \
   Start|3  End
     \  |  /
     2\ | /5
        B
     */
    static Dictionary<string, Dictionary<string, int>> graph = new Dictionary<string, Dictionary<string, int>>();
    static Dictionary<string, int> costs = new Dictionary<string, int>();
    static Dictionary<string, string> parents = new Dictionary<string, string>();
    static List<string> processed = new List<string>();

    private static string GetLowestCostNode()
    {
        int lowestCost = int.MaxValue;
        string lowestCostNode = null;
        foreach(var node in costs)
        {
            if(node.Value < lowestCost && !processed.Contains(node.Key))
            {
                lowestCost = node.Value;
                lowestCostNode = node.Key;
            }
        }
        return lowestCostNode;
    }

    public static void Main()
    {
        // Setting up Graph

        graph.Add("start", new Dictionary<string, int>()
        {
            { "a", 6 },
            { "b", 2 }
        });

        graph.Add("a", new Dictionary<string, int>()
        {
            { "end", 1 }
        });

        graph.Add("b", new Dictionary<string, int>()
        {
            { "end", 5 },
            { "a", 3 }
        });

        graph.Add("end", new Dictionary<string, int>());

        costs.Add("a", 6);
        costs.Add("b", 2);
        costs.Add("end", int.MaxValue);

        parents.Add("a", "start");
        parents.Add("b", "start");
        parents.Add("end", null);

        // Dijkstras Algorithm
        string node = GetLowestCostNode();

        while (node != null)
        {
            int cost = costs[node];
            var neighbours = graph[node];
            foreach(string neighbourNode in neighbours.Keys)
            {
                if(neighbours[neighbourNode] + cost < costs[neighbourNode])
                {
                    costs[neighbourNode] = neighbours[neighbourNode] + cost;
                    parents[neighbourNode] = node;
                }
            }
            processed.Add(node);
            node = GetLowestCostNode();
        }
        // Printing way that we found and it's lengthhh

        List<string> way = new List<string>();
        node = "end";
        way.Add(node);
        while(node != "start")
        {
            way.Add(parents[node]);
            node = parents[node];
        }
        way.Reverse();

        foreach (string currentNode in way)
        {
            Console.Write(currentNode);
            if(currentNode != "end")
            {
                Console.Write("-->");
            }
        }
        
        Console.WriteLine($"\nThe fastest way to get from start to end takes {costs["end"]} minutes");
    }
}