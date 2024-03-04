using System.Collections;

namespace Solution;

public class Stack<T> : IStack<T>
{
    public bool Empty => Count == 0;

    public bool Full => Count == Size;

    public int Count => Count;

    public int Size => Size;

    public Stack(int size = 4)
    {
        Stack<T> stack = new Stack<T>(size);
    }

    public T? Peek()
    {
        throw new NotImplementedException();
    }

    public T? Pop()
    {
        Stack<T> stack = new Stack<T>();
        return stack.Pop();
    }

    public void Push(T Item)
    {
        Stack<T> stack = new Stack<T>();
        stack.Push(Item);
    }
}