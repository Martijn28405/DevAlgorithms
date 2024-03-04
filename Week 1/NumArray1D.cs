using System.Numerics;

namespace ToDo;
public class NumArray1D<T> : Array1D<T>, INumArray1D<T> where T : IComparable<T>, INumber<T>
{
    public NumArray1D(int size = 10):base(size) {  }
    public NumArray1D(T[] data):base(data) { }
  
    public T? Aggregate(Func<T, T, T> fx)
    {
        T result = default;
        for (int i = 0; i < _index; i++)
        {
            result = fx(result, _data[i]);
        }
        return result;
    }

    public T? Max()
    {
        T result = default;
        for (int i = 0; i < _index; i++)
        {
            if (result.CompareTo(_data[i]) < 0)
                result = _data[i];
        }
        return result;
    }

    public T? Min()
    {
        T result = default;
        for (int i = 0; i < _index; i++)
        {
            if (result.CompareTo(_data[i]) > 0)
                result = _data[i];
        }

        return result;
    }

    public T? Product(bool IgnoreZeros = true)
    {
        T result = default;
        for (int i = 0; i < _index; i++)
        {
            if (i == 0)
            {
                result = _data[i];
            }
            else if (IgnoreZeros && _data[i].Equals(default))
                continue;
            else
            {
             result = result * _data[i];     
            }
              
            
        }
        return result;
    }

    public T? Sum()
    {
        T result = default;
        for (int i = 0; i < _index; i++)
        {
            result = result + _data[i];
        }
        return result;
    }
}