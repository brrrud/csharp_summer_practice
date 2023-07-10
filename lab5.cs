namespace labs;

using System;
using System.Collections;
using System.Collections.Generic;


public class LinkedList<T> : IEquatable<LinkedList<T>>, ICloneable, IEnumerable<T>
{
    private class LinkedListNode<T>
    {
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private LinkedListNode<T>? head;
    private LinkedListNode<T>? tail;
    private int count;
    public int Count
    {
        get { return count; }
    }
    public void AddFirst(T value)
    {
        LinkedListNode<T> newNode = new LinkedListNode<T>(value);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
        }
        count++;
    }
    public void AddLast(T value)
    {
        LinkedListNode<T> newNode = new LinkedListNode<T>(value);
        if (head == null) 
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail!.Next = newNode;
            tail = newNode;
        }
        count++;
    }
    public void RemoveFirst()
    {
        if (head != null)
        {
            head = head.Next;
            count--;
            if (head == null)
            {
                tail = null;
            }
        }
    }
    public void RemoveLast()
    {
        if (head != null)
        {
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                LinkedListNode<T> currentNode = head;
                while (currentNode.Next != tail)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = null;
                tail = currentNode;
            }
            count--;
        }
    }
    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }
    public static LinkedList<T> operator *(LinkedList<T> list1, LinkedList<T> list2)
    {
        LinkedList<T> result = new LinkedList<T>();
        int minLength = Math.Min(list1.Count, list2.Count);
        LinkedListNode<T> node1 = list1.head;
        LinkedListNode<T> node2 = list2.head;

        for (int i = 0; i < minLength; i++)
        {
            dynamic value1 = node1.Value;
            dynamic value2 = node2.Value;
            result.AddLast(value1 * value2);

            node1 = node1.Next;
            node2 = node2.Next;
        }

        return result;
    }
    public override int GetHashCode()
    {
        int hashCode = 17;
        LinkedListNode<T> currentNode = head;
        while (currentNode != null)
        {
            hashCode = hashCode * 31 + currentNode.Value.GetHashCode();
            currentNode = currentNode.Next;
        }
        return hashCode;
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return Equals((LinkedList<T>)obj);
    }
    public bool Equals(LinkedList<T> other)
    {
        if (other == null)
            return false;

        if (Count != other.Count)
            return false;

        LinkedListNode<T> currentNode1 = head;
        LinkedListNode<T> currentNode2 = other.head;

        while (currentNode1 != null && currentNode2 != null)
        {
            if (!currentNode1.Value.Equals(currentNode2.Value))
                return false;

            currentNode1 = currentNode1.Next;
            currentNode2 = currentNode2.Next;
        }

        return true;
    }
    public override string ToString()
    {
        LinkedListNode<T> currentNode = head;
        List<string> elements = new List<string>();

        while (currentNode != null)
        {
            elements.Add(currentNode.Value.ToString());
            currentNode = currentNode.Next;
        }

        return string.Join(" -> ", elements);
    }
    public object Clone()
    {
        LinkedList<T> clonedList = new LinkedList<T>();
        LinkedListNode<T> currentNode = head;

        while (currentNode != null)
        {
            clonedList.AddLast(currentNode.Value);
            currentNode = currentNode.Next;
        }

        return clonedList;
    }
    public IEnumerator<T> GetEnumerator()
    {
        LinkedListNode<T> currentNode = head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}