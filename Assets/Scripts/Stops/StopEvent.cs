using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Script defines three classes to define a Stop Event 
/// that can be defined in the inspector of the Stop Controller.
/// </summary>


/// <summary>
/// Class <c>StopEvent</c> defines a Stop Event that can be chosen by the StopController.
/// </summary>
///
[System.Serializable]
public class StopEvent
{
    public string Name;
    [TextArea]
    public string Description;
    // Contains the options from which the player can choose
    public List<StopChoice> Choices;
    // Tracks how often the Event has been already chosen
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

/// <summary>
/// Class <c>StopChoice</c> defines an option the player can choose from.
/// </summary>
///
[System.Serializable]
public class StopChoice
{
    public string Description;
    public List<ResourceModifier> ResourceModifiers;
    [Header("Result")]
    public string ResultTitle;
    [TextArea]
    public string ResultDescription;
    public string ResultContinueText;

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

/// <summary>
/// Class <c>ResourceModifier</c> defines the change in a resource if a specific option is chosen.
/// </summary>
///
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
