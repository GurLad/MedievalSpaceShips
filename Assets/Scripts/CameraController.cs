using UnityEngine;

/// <summary>
/// Class <c>CameraController</c> moves the Camera by according to the x-position of the player Spaceship.
/// </summary>
///
public class CameraController : MonoBehaviour
{
    [SerializeField] Transform Spaceship;

    void Update()
    {
        transform.position = new Vector3(Spaceship.position.x, transform.position.y, transform.position.z);
    }
}
