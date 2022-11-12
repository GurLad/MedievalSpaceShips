using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public static PlayerResources Current;
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
    private Dictionary<ResourceType, int> values;

    private void Awake()
    {
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
    }
}
