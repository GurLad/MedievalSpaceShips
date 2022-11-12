using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsController : MonoBehaviour
{

    [SerializeField] GameObject Eel;
    [SerializeField] GameObject Rock1;
    [SerializeField] GameObject Rock2;
    [SerializeField] GameObject Rock3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomObject(GameObject obj)
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
        Instantiate(obj, screenPosition, Quaternion.identity);
    }
}
