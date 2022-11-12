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

    private void Reset()
    {
        BaseButton = GetComponent<Button>();
        RectTransform = GetComponent<RectTransform>();
    }

    public void Display(StopChoice stopChoice)
    {
        Description.text = stopChoice.Description;
        Resources.text = stopChoice.ResourceModifiersString();
        // TBA: Make sure can actually afford it
    }
}
