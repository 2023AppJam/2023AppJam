using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>();

            return instance;
        }
    }

    private StageInfoPopup stageInfoPopup = null;
    public StageInfoPopup StageInfoPopup
    {
        get
        {
            if (stageInfoPopup == null)
                stageInfoPopup = GameObject.Find("Canvas")?.transform?.Find("StagePanel/StageInfoPanel")?.GetComponent<StageInfoPopup>();

            return stageInfoPopup;
        }
    }

    private GameObject inGamePanel;
    public GameObject InGamePanel
    {
        get
        {
            if (inGamePanel == null)
                inGamePanel = GameObject.Find("Canvas").transform.Find("InGamePanel").gameObject;
            return inGamePanel;
        }
    }

    private GameObject stagePanel;
    public GameObject StagePanel
    {
        get
        {
            if (stagePanel == null)
                stagePanel = GameObject.Find("Canvas").transform.Find("StagePanel").gameObject;
            return stagePanel;
        }
    }

    private BlockSlot slot = null;
    public BlockSlot Slot
    {
        get
        {
            if (slot == null)
                slot = GameObject.Find("Canvas").transform.Find("InGamePanel/BuildingPanel/ItemBox").GetComponent<BlockSlot>();

            return slot;
        }
    }

    private Text remainText = null;
    public Text RemainText
    {
        get
        {
            if (remainText == null)
                remainText = GameObject.Find("Canvas").transform.Find("InGamePanel/RemainTime").GetComponent<Text>();

            return remainText;
        }
    }
}
