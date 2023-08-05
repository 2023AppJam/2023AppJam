using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingBlock : MonoBehaviour
{
    private BlockBuilder blockBuilder;

    private void Start()
    {
        blockBuilder = transform.parent.GetComponent<BlockBuilder>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        blockBuilder.ChangeTracingBlockColor(1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        blockBuilder.ChangeTracingBlockColor(0);
    }
}
