using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopChoiceButton : MonoBehaviour
{
    [Header("Values")]
    public float ResourceIconOffset;
    [Header("Objects")]
    public StopUI StopUI;
    public Text Description;
    public ResourceIcon ResourceIcon;
    [Header("Reset")]
    public Button BaseButton;
    public RectTransform RectTransform;
    private StopChoice stopChoice;

    private void Reset()
    {
        BaseButton = GetComponent<Button>();
        RectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        ResourceIcon.gameObject.SetActive(false);
    }

    public void Display(StopChoice choice)
    {
        stopChoice = choice;
        Description.text = stopChoice.Description;
        for (int i = 0; i < stopChoice.ResourceModifiers.Count; i++)
        {
            ResourceModifier resourceModifier = stopChoice.ResourceModifiers[i];
            ResourceIcon resourceUI = Instantiate(ResourceIcon, ResourceIcon.transform.parent);
            resourceUI.RectTransform.anchoredPosition += new Vector2(i - (stopChoice.ResourceModifiers.Count - 1) / 2.0f, 0) * ResourceIconOffset;
            resourceUI.Show(resourceModifier.Type, resourceModifier.ToString());
            resourceUI.gameObject.SetActive(true);
            if (-resourceModifier.Amount > PlayerResources.Current[resourceModifier.Type])
            {
                BaseButton.interactable = false;
            }
        }
        if (BaseButton.interactable)
        {
            StopUI.LoseButton.SetActive(false);
        }
    }

    public void Choose()
    {
        foreach (ResourceModifier resourceModifier in stopChoice.ResourceModifiers)
        {
            PlayerResources.Current[resourceModifier.Type] += resourceModifier.Amount;
        }
        StopUI.DisplayPostChoice(stopChoice);
    }
}
