using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private const float MIN_SPEED = 2;
    private const float MAX_SPEED = 4;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-Random.Range(MIN_SPEED, MAX_SPEED), Random.Range(-01f, 0.1f), 0);
    }
}
