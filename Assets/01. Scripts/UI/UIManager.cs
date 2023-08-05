using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }
            return _instance;
        }
    }

    private Transform _ui;

    private void Start()
    {
        _ui = GameObject.Find("UI").transform;
    }

    private void Update()
    {
        //_ui.Find("RemainTime").GetComponent<Text>().text =
        //    $"남은 시간 : {StageManager.Instance.CurrentStageInformation.waterAmount}";
    }

    public void ShowPopup(string caption, string content)
    {
        Transform popup = _ui.Find("Popup");
        popup.gameObject.SetActive(true);
        popup.Find("Content").GetComponent<Text>().text = content;
        popup.Find("Title").GetComponent<Text>().text = caption;
    }

    public void ShowStagePopup(string explainText)
    {
        ShowPopup($"스테이지 {StageManager.Instance.currentStage}", explainText);
    }

    public void ClosePopup()
    {
        // 클릭사운드
        Transform popup = _ui.Find("Popup");
        popup.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenItemBox()
    {
        // 클릭사운드
        GameObject itemBox = _ui.Find("ItemBox").gameObject;
        itemBox.SetActive(!itemBox.activeSelf);
    }

    public void StartGame()
    {
        _ui.Find("Levels").gameObject.SetActive(true);
        _ui.Find("Main").gameObject.SetActive(false);
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        ShowPopup("일시정지", "일시정지가 활성화되었습니다.\n재시작하려면 '확인'을 눌러주세요.");
    }
}
