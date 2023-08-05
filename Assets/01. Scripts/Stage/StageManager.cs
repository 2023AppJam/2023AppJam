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
    public StageInformation CurrentStageInformation { get; private set; }
    private GameObject _currentStageGameObject;
    public List<GameObject> stagePrefabs = new();

    public void ClearStage()
    {
        Debug.Log("Stage #" + currentStage + " Cleared!");
        NextStage();
    }

    private void LoadStage()
    {
        if (currentStage >= stagePrefabs.Count)
        {
            Debug.Log("Game Clear!");
            return;
        }
        
        Debug.Log("Destroying GameObject for Stage #" + (currentStage - 1));
        Destroy(_currentStageGameObject);
        _currentStageGameObject = stagePrefabs[currentStage];
        Debug.Log("Instantiating GameObject for Stage #" + currentStage);
        Instantiate(stagePrefabs[currentStage]);
        CurrentStageInformation = _currentStageGameObject.GetComponent<StageInformation>();
    }
    
    private void NextStage()
    {
        currentStage++;
        LoadStage();
    }
}
