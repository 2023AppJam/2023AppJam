using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSceneEvent : MonoBehaviour
{
    public void LaodScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
