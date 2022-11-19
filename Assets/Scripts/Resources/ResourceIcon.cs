using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>ResourceIcon</c> contains the icon and text for the amount of the resource.
/// </summary>
///
public class ResourceIcon : MonoBehaviour
{
    // Stores all Resource Icons, Header adds a Title to the inspector
    [Header("Values")]
    public List<Sprite> TypeSprites;
    [Header("Objects")]
    public Image ResourceImage;
    public Text Text;
    public RectTransform RectTransform;

    private void Reset()
    {
        RectTransform = GetComponent<RectTransform>();
    }

    // Method sets the according Icon and amount text
    public void Show(ResourceType type, string text)
    {
        ResourceImage.sprite = TypeSprites[(int)type];
        Text.text = text;
    }
}
