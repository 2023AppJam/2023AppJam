using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPopup : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.ShowStagePopup("TEST");
    }
}
