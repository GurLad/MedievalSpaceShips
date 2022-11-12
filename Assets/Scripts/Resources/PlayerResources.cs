using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public static PlayerResources Current;
    public float Distance;
    public int this[ResourceType resource]
    {
        get
        {
            return values[resource];
        }
        set
        {
            values[resource] = value;
            ResourceUIPanel.Current?.UpdateUI();
        }
    }
    [SerializeField]
    private int defaultResourceValue;
    [SerializeField]
    private float distanceTarget;
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
        DontDestroyOnLoad(gameObject);
        // Init values
        for (int i = 0; i < (int)ResourceType.End; i++)
        {
            values.Add((ResourceType)i, defaultResourceValue);
        }
        Distance = distanceTarget;
    }
}
