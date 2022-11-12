using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopChoiceButton : MonoBehaviour
{
    [Header("Objects")]
    public Text Description;
    public Text Resources;
    [Header("Reset")]
    public Button BaseButton;
    public RectTransform RectTransform;
    private List<ResourceModifier> resourceModifiers;

    private void Reset()
    {
        BaseButton = GetComponent<Button>();
        RectTransform = GetComponent<RectTransform>();
    }

    public void Display(StopChoice stopChoice)
    {
        Description.text = stopChoice.Description;
        Resources.text = stopChoice.ResourceModifiersString();
        resourceModifiers = stopChoice.ResourceModifiers;
        foreach (ResourceModifier resourceModifier in resourceModifiers)
        {
            if (-resourceModifier.Amount > PlayerResources.Current[resourceModifier.Type])
            {
                BaseButton.enabled = false;
            }
        }
    }

    public void Choose()
    {
        foreach (ResourceModifier resourceModifier in resourceModifiers)
        {
            PlayerResources.Current[resourceModifier.Type] += resourceModifier.Amount;
        }
        // Continue the game loop...
    }
}
