using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsController : MonoBehaviour
{
    public Vector2 Rate;
    public List<SpawnableObject> Objects;
    public Vector2 YRange;
    public float Offset;
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

[System.Serializable]
public class SpawnableObject
{
    public GameObject Object;
    public int Chance;
}