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
        AudioManager.Instance.PlaySystem("ButtonClick");
        StageManager.Instance.SelectStage(stageIndex);
    }

    public void ShowPanel(StageDataSO stageData)
    {
        gameObject.SetActive(true);

        stageText.text = $"스테이지 {stageData.stageIndex}";
        purposeText.text = $"밀려오는 홍수를\n{stageData.runningTime} 초간 버티세요!!";
        slot.SetBlocks(stageData.blockList);

        stageIndex = stageData.stageIndex;
    }

    public void ClosePanel()
    {
        AudioManager.Instance.PlaySystem("ButtonClick");
        gameObject.SetActive(false);
    }
}
