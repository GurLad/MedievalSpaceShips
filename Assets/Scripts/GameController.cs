using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Current;
    public string SideScrollerSceneName;
    public string StopSceneName;
    //private string last

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
