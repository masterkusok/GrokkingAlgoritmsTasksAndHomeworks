class Program
{
    /// <summary>
    /// Returns index of element if array includes this element. If it is not, functions returns -1
    /// </summary>
    /// <param name="array"> Array to perform search in</param>
    /// <param name="element"> Element, which you are looking for</param>
    /// <returns></returns>
    private static int BinarySearch(int[] array, int element)
    {
        int max = array.Length - 1;
        int min = 0;
        while (min <= max)
        {
            int mid = (min + max) / 2;
            if (array[mid] == element)
            {
                return mid;
            }
            else if (array[mid] > element)
            {
                max = mid;
            }
            else
            {
                min = mid + 1;
            }
        }
        return -1;
    }

    public static void Main()
    {
        int[] array = new int[16] { 13, 22, 34, 49, 56, 62, 74, 86, 97, 100, 121, 130, 150, 171, 200, 405 };
        Console.WriteLine(BinarySearch(array, 97));
    }
}