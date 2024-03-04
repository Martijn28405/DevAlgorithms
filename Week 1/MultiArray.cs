using System.Numerics;

namespace ToDo;

public class MultiArray : IMultiArray
{
    public static T[]? RowSum<T>(T[,] arr2D) where T : INumber<T>
    {
        T[] result = default;
        for (int i = 0; i < arr2D.GetLength(0); i++)
        {
            T sum = default;
            for (int j = 0; j < arr2D.GetLength(1); j++)
            {
                sum = sum + arr2D[i, j];
            }
            result[i] = sum;
        }

        return result;
    }
    public static T[]? ColSum<T>(T[,] arr2D) where T : INumber<T>
    {        
        T[] result = default;
        for (int i = 0; i < arr2D.GetLength(1); i++)
        {
            T sum = default;
            for (int j = 0; j < arr2D.GetLength(0); j++)
            {
                sum = sum + arr2D[j, i];
            }
            result[i] = sum;
        }

        return result;
    }

    public static Tuple<int, T>? MaxRowIndexSum<T>(T[][] arrJagged) where T : INumber<T>
    {        
        Tuple<int,T> result = default;
        T maxSum = default;
        for (int i = 0; i < arrJagged.Length; i++)
        {
            T sum = default;
            for (int j = 0; j < arrJagged[i].Length; j++)
            {
                sum = sum + arrJagged[i][j];
            }
            if (sum.CompareTo(maxSum) > 0)
            {
                maxSum = sum;
                result = new Tuple<int, T>(i, maxSum);
            }
        }

        return result;
    }

    public static T?[] MaxCol<T>(T[][] arrJagged) where T : INumber<T>
    {        
        T?[] result = default;
        for (int i = 0; i < arrJagged[0].Length; i++)
        {
            T sum = default;
            for (int j = 0; j < arrJagged.Length; j++)
            {
                sum = sum + arrJagged[j][i];
            }
            result[i] = sum;
        }
        return result;
    }

    public static T[][]? Split<T>(Tuple<T, T, T>[] input)
    {        
        //ToDo
        throw new NotImplementedException();
    }

    public static T[,]? Zip<T>(T[] a, T[] b)
    {        
        //ToDo
        throw new NotImplementedException();
    }
}