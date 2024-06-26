﻿using System.Collections;
using System.Security;

namespace Solution;

public class SinglyLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    public SingleNode<T>? Head;
    private int count;

    public SinglyLinkedList()
    {
        Head = null;
        count = 0;
    }

    public int Count => count;

    public void AddFirst(T value)
    {
        SingleNode<T> newNode = new SingleNode<T>(value);
        newNode.Next = Head;
        Head = newNode;
        count++;
    }

    public void AddLast(T value)
    {
        SingleNode<T> newNode = new SingleNode<T>(value);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            SingleNode<T>? current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public bool Remove(T value)
    {
        if (Head == null)
        {
            return false;
        }

        if (Head.Value.CompareTo(value) == 0)
        {
            Head = Head.Next;
            return true;
        }

        SingleNode<T> current = Head;
        while (current.Next != null)
        {
            if (current.Next.Value.CompareTo(value) == 0)
            {
                current.Next = current.Next.Next;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public SingleNode<T>? Search(T value)
    {
        SingleNode<T>? current = Head;
        while(current != null && current.Value.CompareTo(value) != 0)
        {
            current = current.Next;
        }

        return current;
    }

    public bool Contains(T value) => Search(value) != null;

    public void AddSorted(T value)
{
    SingleNode<T> newNode = new SingleNode<T>(value);
    if (Head == null || Head.Value.CompareTo(value) >= 0)
    {
        newNode.Next = Head;
        Head = newNode;
    }
    else
    {
        SingleNode<T> current = Head;
        while (current.Next != null && current.Next.Value.CompareTo(value) < 0)
        {
            current = current.Next;
        }
        newNode.Next = current.Next;
        current.Next = newNode;
    }
}

    public void Clear()
    {
        Head = null;
    }

    public IEnumerator<T> GetEnumerator()
    {
        SingleNode<T>? current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}