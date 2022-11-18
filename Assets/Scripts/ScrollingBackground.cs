using UnityEngine;

/// <summary>
/// Class <c>ScrollingBackground</c> moves the background mesh image in direction x-axis
/// by a given speed.
/// </summary>
///
public class ScrollingBackground : MonoBehaviour
{
    public float Size = 100;
    public float Speed = -0.1f;

    private void Update()
    {
        // Move the background by speed times deltaTime in x-direction. 
        // If the x position exceeds the size parameter of the background
        // the background x position is set back by the size. 
        transform.position += new Vector3(Time.deltaTime * Speed, 0, 0);
        if (Mathf.Abs(transform.position.x) > Size)
        {
            transform.position += new Vector3(Size, 0, 0);
        }
    }
}
