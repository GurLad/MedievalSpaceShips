using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>StopUI</c> manages the StopPanel. An Event is chosen and its UI displayed.
/// </summary>
///
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
    public GameObject LoseButton;

    // At start, an Event is chosen by the StopController and displayed.
    private void Start()
    {
        // The placeholder Stop Choise Button is disabled
        StopChoiceButton.gameObject.SetActive(false);
        Display(StopController.Choose());
    }

    // Method to read the data from a given Stop Event and create the according UI Elements from it.
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

    // Method to display text after the player chose an event
    public void DisplayPostChoice(StopChoice stopChoice)
    {
        Title.text = stopChoice.ResultTitle;
        Description.text = stopChoice.ResultDescription;
        ContinueText.text = stopChoice.ResultContinueText;
        StopChoicesHolder.SetActive(false);
        ContinueButton.SetActive(true);
    }
}
