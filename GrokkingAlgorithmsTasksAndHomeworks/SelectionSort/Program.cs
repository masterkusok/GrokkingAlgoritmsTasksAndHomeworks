class Program
{
    private static List<int> SelectionSort(List<int> list)
    {
        int numberOfSteps = 0;

        List<int> result = new List<int>();
        for(int i = 0; i < list.Count; i++)
        {
            int smallest = int.MaxValue;
            for(int j = 0; j < list.Count; j++)
            {
                if(list[j] < smallest)
                {
                    smallest = list[j];
                }
                numberOfSteps++;
            }
            list.Remove(smallest);
            i--;
            result.Add(smallest);
        }
        Console.WriteLine($"This sort took {numberOfSteps} steps for {result.Count} elements");
        return result;
    }

    public static void Main()
    {
        List<int> unsortedList = new List<int>{ 123, 3, 1312, 45, 678, 11, 2313, 45454, 88, 12, 999, 10, 123, 3434, 12, 65 };
        foreach(int num in SelectionSort(unsortedList))
        {
            Console.WriteLine(num);
        }
    }
}