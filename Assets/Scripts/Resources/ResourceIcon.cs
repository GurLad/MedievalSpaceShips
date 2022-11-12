using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceIcon : MonoBehaviour
{
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

    public void Show(ResourceType type, string text)
    {
        ResourceImage.sprite = TypeSprites[(int)type];
        Text.text = text;
    }
}
