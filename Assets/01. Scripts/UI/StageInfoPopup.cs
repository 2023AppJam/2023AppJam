using UnityEngine;
using UnityEngine.UI;

public class StageInfoPopup : MonoBehaviour
{
    private Text stageText;
    private Text purposeText;
    private BlockSlot slot;

    private int stageIndex = 0;

    private void Awake()
    {
        Transform bg = transform.Find("BG");
        stageText = bg.Find("StageIndexPanel").Find("Text").GetComponent<Text>();
        purposeText = bg.Find("PurposePanel").Find("Text").GetComponent<Text>();
        slot = bg.Find("BlockInfoPanel").GetComponent<BlockSlot>();
    }

    public void StartStage()
    {
        StageManager.Instance.SelectStage(stageIndex);
    }

    public void ShowPanel(StageDataSO stageData)
    {
        gameObject.SetActive(true);

        stageText.text = $"스테이지 {stageData.stageIndex + 1}";
        purposeText.text = $"{stageData.runningTime} 초 버티셈 ㅋㅋ";
        slot.SetBlocks(stageData.blockList);

        stageIndex = stageData.stageIndex;
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
