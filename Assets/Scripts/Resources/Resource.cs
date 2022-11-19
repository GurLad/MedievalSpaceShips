using System;

/// <summary>
/// Class <c>Resource</c> holds a ResourceType enum value and an amount.
/// </summary>
///
public enum ResourceType { ElectricEels, Health, Food, Engines, Morale, End }
[Serializable]
public class Resource 
{
    public ResourceType type;
    public float amount;
}
