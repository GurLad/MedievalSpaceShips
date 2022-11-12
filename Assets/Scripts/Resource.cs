using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ResourceType { ElectricEels, Health, Food, Engines, Shield, Morale }
[Serializable]
public class Resource 
{
    public ResourceType type;
    public float amount;
}
