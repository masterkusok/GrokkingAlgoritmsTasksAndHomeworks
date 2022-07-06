class Program
{

    private static int[] QuickSort(int[] array)
    {

        if (array.Length == 1 || array.Length == 0)
        {
            return array;
        }

        if (array.Length == 2)
        {
            return array[0] < array[1] ? new int[] { array[0], array[1] } : new int[] { array[1], array[0] };
        }

        int pivot = array[0];
        // Using LINQ
        int[] lower = array.Where(i => i < pivot).ToArray();
        int[] higher = array.Where(i => i > pivot).ToArray();

        /* Non-LINQ
        List<int> lower = new List<int>();
        List<int> higher = new List<int>();
        foreach (int i in array)
        {
            if (i < pivot)
            {
                lower.Add(i);
                continue;
            }
            higher.Add(i);
        }
        lower.Add(pivot);*/

        return QuickSort(lower).Concat(new int[]{ pivot}.Concat(QuickSort(higher))).ToArray();
    }

    public static void Main()
    {
        int[] array = new int[] { 123, 43, 66, 33, 12, 98, 34, 0 };
        array = QuickSort(array);
        foreach(int i in array)
        {
            Console.WriteLine(i);
        }
    }
}