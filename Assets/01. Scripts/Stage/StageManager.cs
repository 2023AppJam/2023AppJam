using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    
    # region Singleton
    
    private static StageManager _instance;

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

    public static StageManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StageManager>();
            }
            return _instance;
        }
    }

    #endregion

    public int currentStage { get; private set; }

    private StageInformation _currentStageInfo;
    public StageInformation CurrentStageInfo => _currentStageInfo;

    public void ClearStage()
    {
        Debug.Log("Stage #" + currentStage + " Cleared!");
        // Å¬¸®¾î ÆË¾÷ ¶ç¿ì±â
        GameManager.Instance.InGamePanel.transform.GetChild(3).gameObject.SetActive(true);
    }
    
    public void SelectStage(int stageNumber)
    {
        currentStage = stageNumber;
        LoadStage();
    }

    public void RestartStage()
    {
        LoadStage();
    }

    public void NextStage()
    {
        currentStage++;
        LoadStage();
    }

    private void LoadStage()
    {
        if (GameManager.Instance.StagePanel)
            GameManager.Instance.StagePanel.SetActive(false);
        
        if (_currentStageInfo)
            PoolManager.Instance.Push(_currentStageInfo);

        _currentStageInfo = PoolManager.Instance.Pop($"Stage{currentStage}") as StageInformation;
        _currentStageInfo.transform.position = Vector3.zero;

        GameManager.Instance.InGamePanel.SetActive(true);
        GameManager.Instance.Slot.SetBlocks(_currentStageInfo.StageData.blockList);
    }
}
