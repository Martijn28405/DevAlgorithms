using System.Net;
using System.Numerics;

namespace ToDo;

public class MultiArray : IMultiArray
{
    public static T[]? RowSum<T>(T[,] arr2D) where T : INumber<T>
    {
        T[] result = new T[arr2D.GetLength(1)];
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
        T[] result = new T[arr2D.GetLength(1)];
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

        int colCount = arrJagged[0].Length;
        T?[] result = new T[colCount];
        
        for (int i = 0; i < colCount; i++)
        {
            T sum = default;
            for (int j = 0; j < arrJagged.Length; j++)
            {
                if (arrJagged[j].Length <= i)
                {
                    continue;
                }
                sum += arrJagged[j][i];
            }
            result[i] = sum;
        }
        
        return result;
    }

    public static T[][]? Split<T>(Tuple<T, T, T>[] input)
    {        
        //ToDo
        int length = input.Length;
        int halfLength = length / 2;
        T[][] result = new T[halfLength][];
        for (int i = 0; i < halfLength; i++)
        {
            result[i] = new T[] { input[i].Item1, input[i].Item2, input[i].Item3 };
        }
        return result;
    }

    public static T[,]? Zip<T>(T[] a, T[] b)
    {        
        int length = a.Length < b.Length ? a.Length : b.Length;
        T[,] result = new T[length, 2];
        for (int i = 0; i < length; i++)
        {
            result[i, 0] = a[i];
            result[i, 1] = b[i];
        }
        return result;
    }
}