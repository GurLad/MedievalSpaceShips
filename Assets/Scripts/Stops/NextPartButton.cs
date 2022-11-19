using UnityEngine;

/// <summary>
/// Class <c>NextPartButton</c> gets triggered by the continue button 
/// and changes again the scene to the sidescrolling part.
/// </summary>
///
public class NextPartButton : MonoBehaviour
{
    public void Click()
    {
        GameController.Current.LoadNextPart();
    }
}
