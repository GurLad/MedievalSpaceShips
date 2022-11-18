using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>SpawnObjectsController</c> moves the Camera by according to the x-position of the player Spaceship.
/// </summary>
///
public class SpawnObjectsController : MonoBehaviour
{
    // The spawnable objects are defined in the unity inspector
    public List<SpawnableObject> Objects;
    public Vector2 Rate;
    public Vector2 YRange;
    public float Offset;
    private float count = 0;
    private int totalCount;

    // Initilize the total count by the given objects and their changes.
    void Start()
    {
        foreach (SpawnableObject obj in Objects)
        {
            totalCount += obj.Chance;
        }
    }

    // Handle the rate of respawning new objects
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
                    count = Random.Range(Rate.x, Rate.y);
                    return;
                }
            }
        }
        else
        {
            count -= Time.deltaTime;
        }
    }

    // Method to spawn an object (obstacle or resource) into the scene, starting at a random position.
    void SpawnRandomObject(GameObject obj)
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
        GameObject newObj = Instantiate(obj, screenPosition, Quaternion.identity);
        newObj.name = obj.name;
        newObj.transform.position = new Vector3(Camera.main.transform.position.x + Offset, Random.Range(YRange.x, YRange.y), 0);
        newObj.SetActive(true);
        newObj.AddComponent<ObjectMover>();
    }
}

// A general class for a spawnable object. 
// This has a chance property that indicates how propable it is that this object will be spawned.
[System.Serializable]
public class SpawnableObject
{
    public GameObject Object;
    public int Chance;
}