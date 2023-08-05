using UnityEngine;

public class StageButton : MonoBehaviour
{
    [SerializeField] StageDataSO stageData; // Set Stage Info Popup

    public void ShowStageInfo()
    {
        GameManager.Instance.StageInfoPopup?.ShowPanel(stageData);
        AudioManager.Instance.PlaySystem("ButtonClick");
    }
}
