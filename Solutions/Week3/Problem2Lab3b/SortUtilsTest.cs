namespace Problem2Lab3b
{
    public class SortUtilsTest
    {
        public static void Main()
        {
            // get arr 1
            int[] arr1 = new int[8];

            Console.WriteLine("Enter arr1: (split numbers with enter)");
            SortUtils.InitArray(arr1);

            // print arr1
            Console.WriteLine("\narr1: ");
            SortUtils.PrintArray(arr1);

            // get arr2
            int[] arr2 = new int[8];
            Console.WriteLine("Enter arr2: (split numbers with enter)");
            SortUtils.InitArray(arr2);

            // sort arrays
            SortUtils.SortArray(arr1);
            SortUtils.SortArray(arr2);

            Console.WriteLine("\narr1 sorted:");
            SortUtils.PrintArray(arr1);

            // test merge
            int[] arr3 = SortUtils.MergeSort(arr1, arr2);
            Console.WriteLine("arr3:");
            SortUtils.PrintArray(arr3);
        }
    }
}