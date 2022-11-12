using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Current;

    private void Awake()
    {
        // Init singelton
        transform.parent = null;
        if (Current != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        else
        {
            Current = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadNextPart()
    {
        // Temp
        SceneLoader.LoadScene("GurSandbox");
    }
}
