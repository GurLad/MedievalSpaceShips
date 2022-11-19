using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>PlayerResources</c> holds and manages the Resource data of the player.
/// </summary>
///
public class PlayerResources : MonoBehaviour
{
    public static PlayerResources Current;
    public float Distance;
    // Definition of the access of the object, depending on the given ResourceType
    // the values data structure is indexed to get the resource amount
    // or a given value is set in the data structure and the Resource UI is updated with the new amount.
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
    // The data structure that stores all resourecs and their amounts
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
        ResetData();
    }

    // Method resets all resource amounts
    public void ResetData()
    {
        for (int i = 0; i < (int)ResourceType.End; i++)
        {
            values[(ResourceType)i] = defaultResourceValue;
        }
        Distance = distanceTarget;
    }
}
