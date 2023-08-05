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

    private BlockSlot slot = null;
    public BlockSlot Slot {
        get {
            if (slot == null)
                slot = GameObject.Find("ItemBox")?.GetComponent<BlockSlot>();

            return slot;
        } 
    }

    public int currentStage { get; private set; }
    
    private GameObject stageUICanvas;
    public GameObject StageUICanvas {
        get {
            if (stageUICanvas == null)
                stageUICanvas = GameObject.Find("StageUI");
            return stageUICanvas;
        }
    }

    private StageInformation _currentStageInfo;

    public void ClearStage()
    {
        Debug.Log("Stage #" + currentStage + " Cleared!");
        // TODO Display Stage Clear UI
        if (StageUICanvas)
        {
            StageUICanvas.SetActive(true);
        }
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
        if (StageUICanvas)
        {
            StageUICanvas.SetActive(false);
        }

        //if (currentStage >= stagePrefabs.Count)
        //{
        //    Debug.Log("Game Clear!");
        //    return;
        //}
        
        //Debug.Log("Destroying GameObject for Stage #" + (currentStage - 1));
        if (_currentStageInfo)
        {
            PoolManager.Instance.Push(_currentStageInfo);
            //Destroy(_currentStageGameObject);
        }

        _currentStageInfo = PoolManager.Instance.Pop($"Stage{currentStage}") as StageInformation;
        //Debug.Log($"Stage{currentStage}");
        _currentStageInfo.transform.position = Vector3.zero;
        //Debug.Log(_currentStageInfo);
        //Debug.Log("Instantiating GameObject for Stage #" + currentStage);

        Slot.SetBlocks(_currentStageInfo.StageData.blockList);

        //Instantiate(stagePrefabs[currentStage]); // Edit later using PoolManager
    }
}
