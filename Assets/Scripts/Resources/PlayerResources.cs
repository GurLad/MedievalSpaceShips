using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public static PlayerResources Current;
    public int DefaultResourceValue;
    public int this[ResourceType resource]
    {
        get
        {
            return values[resource];
        }
        set
        {
            values[resource] = value;
        }
    }
    private Dictionary<ResourceType, int> values = new Dictionary<ResourceType, int>();

    private void Awake()
    {
        // Init singelton
        transform.parent = null;
        if (Current != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        else
        {
            Current = this;
        }
        // Init values
        for (int i = 0; i < (int)ResourceType.End; i++)
        {
            values.Add((ResourceType)i, DefaultResourceValue);
        }
    }
}
