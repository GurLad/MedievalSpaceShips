using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StopEvent
{
    public string Name;
    [TextArea]
    public string Description;
    public List<StopChoice> Choices;
    [HideInInspector]
    public int TimesChosen
    {
        get
        {
            return PlayerPrefs.GetInt("TimesChosen" + Name);
        }
        set
        {
            PlayerPrefs.SetInt("TimesChosen" + Name, value);
        }
    }
}

[System.Serializable]
public class StopChoice
{
    public string Description;
    public List<ResourceModifier> ResourceModifiers;

    public string ResourceModifiersString()
    {
        if (ResourceModifiers.Count > 0)
        {
            string result = "(";
            for (int i = 0; i < ResourceModifiers.Count; i++)
            {
                result +=
                    (i > 0 ? ", " : "") +
                    (ResourceModifiers[i].Amount > 0 ? "+" : "") +
                    ResourceModifiers[i].Amount + " " +
                    ResourceModifiers[i].Type;
            }
            return result + ")";
        }
        else
        {
            return "(Nothing)";
        }
    }
}

[System.Serializable]
public class ResourceModifier
{
    public ResourceType Type;
    public int Amount;

    public override string ToString()
    {
        return (Amount > 0 ? "+" : "") + Amount;
    }
}
