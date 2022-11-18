using UnityEngine;

/// <summary>
/// Class <c>Quit</c> handles click event of the Quit button in the menu. It quits the game application.
/// </summary>
///
public class Quit : MonoBehaviour
{
    public void Click()
    {
        Application.Quit();
    }
}
