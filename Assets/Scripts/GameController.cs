using UnityEngine;

/// <summary>
/// Class <c>GameController</c> handles game progression loads scenes accordingly.
/// </summary>
///
public class GameController : MonoBehaviour
{
    public static GameController Current;
    public string SideScrollerSceneName;
    public string StopSceneName;
    private string currentScene;

    // Initialize the Game Controller as a singleton
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

    // Method to load the side-scroller part or stop events according to the currently set scene
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

    // The method handles scene loading in case of winning the game
    public void Win()
    {
        SceneLoader.LoadScene("Win");
    }

    // The method handles scene loading in case of loosing the game
    public void Lose()
    {
        SceneLoader.LoadScene("Lose");
    }
}
