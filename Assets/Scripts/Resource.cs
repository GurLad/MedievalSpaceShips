using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Resource 
{
   public enum ResourceType { Energy, Health }
    public ResourceType type;
    public float amount;

}
