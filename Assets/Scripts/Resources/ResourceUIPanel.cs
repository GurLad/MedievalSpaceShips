using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceUIPanel : MonoBehaviour
{
    public static ResourceUIPanel Current;
    [Header("Values")]
    public float IconOffset;
    [Header("Objects")]
    public ResourceIcon BaseIcon;
    private List<ResourceIcon> icons = new List<ResourceIcon>();

    private void Awake()
    {
        Current = this;
    }

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

    public void UpdateUI()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].Show((ResourceType)i, ((ResourceType)i).ToFormattedString() + ": " + PlayerResources.Current[(ResourceType)i]);
        }
    }
}
