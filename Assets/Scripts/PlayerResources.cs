using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public Resource Health;
    public Resource Energy;



    public void LooseResource(Resource.ResourceType type,float amount)
    {
        switch (type)
        {
            case Resource.ResourceType.Health: Health.amount -= amount; break;
            case Resource.ResourceType.Energy: Energy.amount -= amount; break;
        }
    }

    public void GainResource(Resource.ResourceType type,float amount)
    {
        switch (type)
        {
            case Resource.ResourceType.Health: Health.amount += amount; break;
            case Resource.ResourceType.Energy: Energy.amount += amount; break;
        }
    }

}
