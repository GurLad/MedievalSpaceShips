using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopChoiceButton : MonoBehaviour
{
    [Header("Values")]
    public float ResourceIconOffset;
    [Header("Objects")]
    public Text Description;
    public ResourceIcon ResourceIcon;
    [Header("Reset")]
    public Button BaseButton;
    public RectTransform RectTransform;
    private List<ResourceModifier> resourceModifiers;

    private void Reset()
    {
        BaseButton = GetComponent<Button>();
        RectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        ResourceIcon.gameObject.SetActive(false);
    }

    public void Display(StopChoice stopChoice)
    {
        Description.text = stopChoice.Description;
        resourceModifiers = stopChoice.ResourceModifiers;
        for (int i = 0; i < resourceModifiers.Count; i++)
        {
            ResourceModifier resourceModifier = resourceModifiers[i];
            ResourceIcon resourceUI = Instantiate(ResourceIcon, ResourceIcon.transform.parent);
            resourceUI.RectTransform.anchoredPosition += new Vector2(i - (resourceModifiers.Count - 1) / 2.0f, 0) * ResourceIconOffset;
            resourceUI.Show(resourceModifier.Type, resourceModifier.ToString());
            resourceUI.gameObject.SetActive(true);
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
