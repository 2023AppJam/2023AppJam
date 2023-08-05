using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Waterspout : PoolableMono
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 4)
            PoolManager.Destroy(collision.gameObject);
    }

    public override void Init()
    {
    }
}
