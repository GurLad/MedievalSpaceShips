using UnityEngine;

public class NextPartButton : MonoBehaviour
{
    public void Click()
    {
        GameController.Current.LoadNextPart();
    }
}
