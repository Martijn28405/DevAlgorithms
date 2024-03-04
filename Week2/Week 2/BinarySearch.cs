namespace ToDo;

public class BinarySearch{

    public static int binarySearch<T>(T[] a, T v) where T : IComparable
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

        return -1;
    }

    public static int binarySearchRecursive<T>(T[] a, int low, int high, T v) where T : IComparable
    {
        if (high >= low)
        {
            int mid = low + (high - low) / 2;
            int res = a[mid].CompareTo(v);

            if (res == 0)
                return mid;

            if (res > 0)
                return binarySearchRecursive(a, low, mid - 1, v);
            if (res < 0)
            {
              return binarySearchRecursive(a, mid + 1, high, v);  
            }
            
        }

        return -1; // return -1 if the element is not present in the array
    }

}