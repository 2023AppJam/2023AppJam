using UnityEngine;

public class StageStartEvent : MonoBehaviour
{
    public void StartStage()
    {
        StageManager.Instance.CurrentStageInfo.StartSequence();
    }
}