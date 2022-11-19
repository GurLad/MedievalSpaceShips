using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>ResourceUIPanel</c> draws the Resource UI Icons and texts as well as the distance to the home planet.
/// </summary>
///
public class ResourceUIPanel : MonoBehaviour
{
    public static ResourceUIPanel Current;
    [Header("Values")]
    public float IconOffset;
    [Header("Objects")]
    public ResourceIcon BaseIcon;
    public Text DistanceText;
    // A list with all resource icons instantiated at start
    private List<ResourceIcon> icons = new List<ResourceIcon>();

    private void Awake()
    {
        Current = this;
    }

    // At the start the placeholder BaseIcon is deactivated and for each Resource an Icon is instantiated.
    private void Start()
    {
        BaseIcon.gameObject.SetActive(false);
        for (int i = 0; i < (int)ResourceType.End; i++)
        {
            ResourceIcon newIcon = Instantiate(BaseIcon, BaseIcon.transform.parent);
            newIcon.RectTransform.anchoredPosition += new Vector2(i, 0) * IconOffset;
            newIcon.gameObject.SetActive(true);
            icons.Add(newIcon);
        }
        UpdateUI();
    }

    // The UI is updated according to the player resource data
    public void UpdateUI()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].Show((ResourceType)i, ((ResourceType)i).ToFormattedString() + ": " + PlayerResources.Current[(ResourceType)i]);
        }
        DistanceText.text = "Distance: " + (int)PlayerResources.Current.Distance;
    }
}
