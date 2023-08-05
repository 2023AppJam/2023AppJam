using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtons : MonoBehaviour
{
    public void ButtonRestartStage()
    {
        StageManager.Instance.RestartStage();
    }
    public void ButtonNextStage()
    {
        StageManager.Instance.NextStage();
    }

    public void ButtonStageSelectPanel()
    {
        GameObject.Find("InGamePanel").transform.GetChild(2).gameObject.SetActive(false);
        GameObject.Find("InGamePanel").transform.GetChild(3).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
    }
}
