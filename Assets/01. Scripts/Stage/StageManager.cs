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
    public GameObject canvas;
    private StageInformation _currentStageInfo;

    public void ClearStage()
    {
        Debug.Log("Stage #" + currentStage + " Cleared!");
        // TODO Display Stage Clear UI
        if (canvas)
        {
            canvas.SetActive(true);
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
        if (canvas)
        {
            canvas.SetActive(false);
        }

        //if (currentStage >= stagePrefabs.Count)
        //{
        //    Debug.Log("Game Clear!");
        //    return;
        //}
        
        Debug.Log("Destroying GameObject for Stage #" + (currentStage - 1));
        if (_currentStageInfo)
        {
            PoolManager.Instance.Push(_currentStageInfo);
            //Destroy(_currentStageGameObject);
        }
        _currentStageInfo = PoolManager.Instance.Pop($"Stage{currentStage}") as StageInformation;
        _currentStageInfo.transform.position = Vector3.zero;
        Debug.Log("Instantiating GameObject for Stage #" + currentStage);

        //Instantiate(stagePrefabs[currentStage]); // Edit later using PoolManager
    }
}
