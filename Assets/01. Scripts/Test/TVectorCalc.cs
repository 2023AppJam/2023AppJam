using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVectorCalc : MonoBehaviour
{
    [SerializeField] Transform from, to;

    private void Awake()
    {
        Debug.Log((to.position - from.position).normalized);
    }
}
