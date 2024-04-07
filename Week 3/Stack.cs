public class Stack<T> : SimpleStack<T>
{
    public override void Push(T item)
    {
        if (top == Capacity - 1)
        {
            Capacity *= 2;
            T?[] newArr = new T[Capacity];
            for (int i = 0; i <= top; i++)
            {
                newArr[i] = arr[i];
            }
            arr = newArr;
        }
        arr[++top] = item;
    }

    public override T? Peek()
    {
        if (IsEmpty())
            throw new StackEmptyException("The Stack is empty.");
        return arr[top];
    }
    
    public override T? Pop()
    {
        if (IsEmpty())
            throw new StackEmptyException("The Stack is empty.");
        T? temp = arr[top];
        arr[top] = default(T);
        top--;
        return temp;
    }
}