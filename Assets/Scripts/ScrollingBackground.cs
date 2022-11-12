using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float Size;
    public float Speed;

    private void Update()
    {
        transform.position += new Vector3(Time.deltaTime * Speed, 0, 0);
        if (transform.position.x > Size)
        {
            transform.position -= new Vector3(Size, 0, 0);
        }
    }
}
