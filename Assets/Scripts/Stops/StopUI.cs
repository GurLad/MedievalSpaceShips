using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopUI : MonoBehaviour
{
    [Header("Values")]
    public float ButtonOffset;
    [Header("Objects")]
    public StopController StopController;
    public Text Title;
    public Text Description;
    public StopChoiceButton StopChoiceButton;
    public GameObject StopChoicesHolder;
    public GameObject ContinueButton;
    public Text ContinueText;

    private void Start()
    {
        StopChoiceButton.gameObject.SetActive(false);
        Display(StopController.Choose());
    }

    public void Display(StopEvent stopEvent)
    {
        Title.text = stopEvent.Name;
        Description.text = stopEvent.Description;
        for (int i = 0; i < stopEvent.Choices.Count; i++)
        {
            StopChoiceButton newButton = Instantiate(StopChoiceButton, StopChoiceButton.transform.parent);
            newButton.Display(stopEvent.Choices[i]);
            newButton.RectTransform.anchoredPosition += new Vector2(0, ButtonOffset * (stopEvent.Choices.Count - 1 - i));
            newButton.gameObject.SetActive(true);
        }
        StopChoicesHolder.SetActive(true);
        ContinueButton.SetActive(false);
    }

    public void DisplayPostChoice(StopChoice stopChoice)
    {
        Title.text = stopChoice.ResultTitle;
        Description.text = stopChoice.ResultDescription;
        ContinueText.text = stopChoice.ResultContinueText;
        StopChoicesHolder.SetActive(false);
        ContinueButton.SetActive(true);
    }
}
