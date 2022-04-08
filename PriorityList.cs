using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityList<T> where T : IPriority
{
    private List<T> list;
    
    public PriorityList() : this(new List<T>())
    { }

    public PriorityList(List<T> list)
    {
        this.list = list;
    }

    public List<T> GetList()
    {
        return list;
    }

    public void Add(T obj)
    {
        int index = IndexOf(obj);

        if (index >= 0)
        {
            list.Insert(index, obj);
        }
        else
        {
            list.Add(obj);
        }
    }

    public void Remove(T obj)
    {
        Remove(obj);
    }

    public void Remove(int index)
    {
        list.RemoveAt(index);
    }

    public int IndexOf(T obj)
    {
        int index = 0;
        
        foreach (T listObj in list)
        {
            if (obj.GetPriority() < listObj.GetPriority())
            {
                return index;
            }

            index++;
        }

        return -1;
    }

    
}
