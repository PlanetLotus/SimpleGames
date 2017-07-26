using System;
using UnityEngine;

public class Cube : MonoBehaviour, IComparable
{
    public int Data { get; set; }

    public int CompareTo(object value)
    {
        var intVal = ((Cube)value).Data;
        return Data.CompareTo(intVal);
    }
}
