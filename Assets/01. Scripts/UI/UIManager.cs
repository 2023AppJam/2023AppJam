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
        _ui.Find("RemainTime").GetComponent<Text>().text =
            $"남은 시간 : {StageManager.Instance.CurrentStageInformation.waterAmount}";
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

    public void OnClick()
    {
        Transform popup = _ui.Find("Popup");
        popup.gameObject.SetActive(false);
    }
}
