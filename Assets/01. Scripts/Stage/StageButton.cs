using UnityEngine;

public class StageButton : MonoBehaviour
{
    [SerializeField] StageDataSO stageData; // Set Stage Info Popup

    public void LoadStage()
    {
        StageManager.Instance.SelectStage(stageData.stageIndex);
    }
}
