using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleButtonEvent : MonoBehaviour
{
    public void LaodScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
