using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform Spaceship;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Spaceship.position.x, transform.position.y, transform.position.z);
    }
}