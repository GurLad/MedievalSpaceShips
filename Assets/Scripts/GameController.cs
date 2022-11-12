using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Current;
    public string SideScrollerSceneName;
    public string StopSceneName;
    private string currentScene;

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
        if (currentScene == SideScrollerSceneName)
        {
            SceneLoader.LoadScene(currentScene = StopSceneName);
        }
        else
        {
            SceneLoader.LoadScene(currentScene = SideScrollerSceneName);
        }
    }

    public void Win()
    {
        SceneLoader.LoadScene("Win");
    }

    public void Lose()
    {
        SceneLoader.LoadScene("Lose");
    }
}
