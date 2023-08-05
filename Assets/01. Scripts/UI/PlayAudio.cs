using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public void PlaySystem(string clipName)
    {
        AudioManager.Instance.PlaySystem(clipName);
    }
}
