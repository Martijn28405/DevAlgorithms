namespace ToDo;

public class Sort<T> : ISort<T> where T : IComparable<T>
{
    public static void BubbleSort(T[] data)
    {
        int n = data.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (data[j].CompareTo(data[j + 1]) > 0)
                {
                    // swap data[j] and data[j + 1]
                    T temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                }
            }
        }
    }

    public static void InsertionSort(T[] data)
    {
        for (int i = 1; i < data.Length; i++)
        {
            T key = data[i];
            int j = i - 1;

            // Move elements of data[0..i-1], that are greater than key,
            // to one position ahead of their current position
            while (j >= 0 && data[j].CompareTo(key) > 0)
            {
                data[j + 1] = data[j];
                j = j - 1;
            }

            data[j + 1] = key;
        }
    }


    public static void MergeSort(T[] array, int low, int high)
    {
        if (low < high)
        {
            // Find the middle point
            int mid = (low + high) / 2;

            // Sort first and second halves
            MergeSort(array, low, mid);
            MergeSort(array, mid + 1, high);

            // Merge the sorted halves
            Merge(array, low, mid, high);
        }
    }

    public static void Merge(T[] array, int low, int mid, int high)
{
    int left = low;
    int right = mid + 1;
    T[] temp = new T[high - low + 1];
    int tempIndex = 0;

    // Merge the two halves into temp[]
    while (left <= mid && right <= high)
    {
        if (array[left].CompareTo(array[right]) <= 0)
        {
            temp[tempIndex] = array[left];
            left++;
        }
        else
        {
            temp[tempIndex] = array[right];
            right++;
        }
        tempIndex++;
    }

    // Copy the remaining elements of left[], if there are any
    while (left <= mid)
    {
        temp[tempIndex] = array[left];
        left++;
        tempIndex++;
    }

    // Copy the remaining elements of right[], if there are any
    while (right <= high)
    {
        temp[tempIndex] = array[right];
        right++;
        tempIndex++;
    }

    // Copy the merged elements back into the original array
    for (left = low, tempIndex = 0; left <= high; left++, tempIndex++)
    {
        array[left] = temp[tempIndex];
    }
}
}