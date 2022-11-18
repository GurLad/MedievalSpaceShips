using UnityEngine;

/// <summary>
/// Class <c>Lose</c> handles the click event of the Lose Button while a stop event.
/// This button only appears when no trading option is possible to take due to missing resources.
/// </summary>
///
public class Lose : MonoBehaviour
{
    public void Click()
    {
        GameController.Current.Lose();
    }
}
