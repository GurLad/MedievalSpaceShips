using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static string ToFormattedString(this ResourceType type)
    {
        return type == ResourceType.ElectricEels ? "Eels" : type.ToString();
    }
}
