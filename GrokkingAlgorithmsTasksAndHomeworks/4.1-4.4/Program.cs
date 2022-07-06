class Program
{
    /// <summary>
    /// Task 4.1. Sums all elements of array
    /// </summary>
    /// <returns></returns>
    public static int Sum(int[] array)
    {
        if(array.Length == 0)
        {
            return 0;
        }
        if(array.Length == 1)
        {
            return array[0];
        }
        // Sum first element and sum of all the rest array
        return array[0] + Sum(array[1..]);
    }

    /// <summary>
    /// Task 4.2
    /// </summary>
    
    public static int GetLength(List<int> list)
    {
        if(!list.Any())
        {
            return 0;
        }
        else
        {
            list.RemoveAt(0);
            return 1 + GetLength(list);
        }
    }

    /// <summary>
    /// Task 4.3
    /// </summary>

    public static int FindSmallestNum(List<int> list)
    {
        if(list.Count == 0)
        {
            return int.MaxValue;
        }

        int current = list[0];
        list.RemoveAt(0);
        int last = FindSmallestNum(list);

        if(last < current)
        {
            return last;
        }

        return current;
    }

    public static void Main()
    {

    }
}