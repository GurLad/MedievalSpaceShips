using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsController : MonoBehaviour
{
    public Vector2 Rate;
    public List<SpawnableObject> Objects;
    private float count = 0;
    private int totalCount;

    // Start is called before the first frame update
    void Start()
    {
        foreach (SpawnableObject obj in Objects)
        {
            totalCount += obj.Chance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 0)
        {
            int result = Random.Range(1, totalCount);
            foreach (SpawnableObject obj in Objects)
            {
                result -= obj.Chance;
                if (result <= 0)
                {
                    SpawnRandomObject(obj.Object);
                }
            }
        }
    }

    void SpawnRandomObject(GameObject obj)
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
        GameObject newObj = Instantiate(obj, screenPosition, Quaternion.identity);
        newObj.AddComponent<ObjectMover>();
    }
}

[SerializeField]
public class SpawnableObject
{
    public GameObject Object;
    public int Chance;
}