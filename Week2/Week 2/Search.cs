namespace ToDo;

public class Search<T> : ISearch<T> where T:IComparable<T>{

    public static int SequentialSearch(T[] a, T v)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].CompareTo(v) == 0)
                return i;
        }
        return -1; // return -1 if the element is not present in the array
    }

    public static int BinarySearch(T[] a, T v) 
    {        
        int low = 0;
        int high = a.Length - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            int res = a[mid].CompareTo(v);

            if (res == 0)
                return mid;

            if (res < 0)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return -1; // return -1 if the element is not present in the array
    }

    public static int BinarySearchRecursive(T[] a, T v, int low, int high)
    {
        Utils.ShowCallStack();

        if (high >= low)
        {
            int mid = low + (high - low) / 2;
            int res = a[mid].CompareTo(v);

            if (res == 0)
                return mid;

            if (res > 0)
                return BinarySearchRecursive(a, v, low, mid - 1);

            return BinarySearchRecursive(a, v, mid + 1, high);
        }

        return -1; // return -1 if the element is not present in the array
    }

}