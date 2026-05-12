using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
public static class CollectionProcessor
{
    public static void RemoveAfter<T>(List<T> list, T e)
    {
        if (list == null)
        {
            return;
        }
        if (list.Count < 2)
        {
            return;
        }

        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (Equals(list[i], e))
            {
                if (i <= list.Count)
                {
                    if (!Equals(list[i + 1], e))
                    {
                        list.RemoveAt(i + 1);
                    }
                }
            }
        }
    }
    public static bool IsSameNeighbors<T>(LinkedList<T> list)
    {
        if (list == null || list.Count == 0)
        {
            return false;
        }
        if (list.Count == 1)
        {
            return true;
        }
        if(Equals(list.First.Value, list.Last.Value))
        {
            return true;
        }
        LinkedListNode<T> current = list.First;

        for (int i = 1; i < list.Count; i++)
        {
            LinkedListNode<T> next = current.Next;
            if (Equals(current.Value, next.Value))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }
    public static void PrintAnalizedContries(
        List<HashSet<string>> tourists,
        List<string> countries)
    {
        Console.WriteLine("Список стран: ");
        foreach(string country in countries)
        {
            Console.Write(country + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Список стран, посещённых " +
            "туристами: ");
        foreach(HashSet<string> tourist in tourists)
        {
            foreach(string country in tourist)
            {
                Console.Write(country + " ");
            }
            Console.WriteLine();
        }
        HashSet<string> visitedBySome = new HashSet<string>();
        Console.WriteLine("Список стран, которые посетили" +
            " хотя бы 1 раз");
        foreach (var tourist in tourists)
        {
            visitedBySome.UnionWith(tourist);
        }
        foreach(string country in visitedBySome)
        {
            Console.Write(country + " ");
        }
        Console.WriteLine();

        HashSet<string> allVisited = new HashSet<string>(tourists[0]);
        for (int i = 1; i < tourists.Count; i++)
        {
            allVisited.IntersectWith(tourists[i]);
        }
        Console.WriteLine("Список стран, которые посетили" +
            " все");
        foreach (string country in allVisited)
        {
            Console.Write(country + " ");
        }
        Console.WriteLine();

        HashSet<string> notVisited = new HashSet<string>(countries);
        notVisited.ExceptWith(visitedBySome);
        Console.WriteLine("Список стран, которые " +
            "никто не посетил");
        foreach (string country in notVisited)
        {
            Console.Write(country + " ");
        }
        Console.WriteLine();
    }
}
