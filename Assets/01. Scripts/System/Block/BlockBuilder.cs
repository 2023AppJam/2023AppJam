using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockBuilder : MonoBehaviour
{
    //[SerializeField] private StageManager stageManager;

    //[SerializeField] private GameObject[] buildingBlocks;
    [SerializeField] private GameObject tracingBlock;
    private SpriteRenderer tracingBlockSpr;
    private bool blockSelected;
    private bool buildAble;
    private int selectBlock;
    private Vector3 mousePos;
    [SerializeField] private Color[] tracingBlockColors;

    private BlockDataSO currentBlockData;
    private Action onBuildEvent;

    private void Start()
    {
        tracingBlockSpr = tracingBlock.GetComponent<SpriteRenderer>();
    }

    public void ChangeTracingBlockColor(int colorNum)
    {
        tracingBlockSpr.color = tracingBlockColors[colorNum];
        if (colorNum == 0) { buildAble = true; }
        else if (colorNum == 1) { buildAble = false; }
    }

    public void ChangeBlock(BlockDataSO blockData, Action callback = null)
    {
        onBuildEvent = callback;

        currentBlockData = blockData;

        tracingBlockSpr.sprite = currentBlockData.blockSprite;
        tracingBlock.SetActive(true);
        tracingBlockSpr.color = tracingBlockColors[0];
        
        // »Ï
        tracingBlock.GetComponent<PolygonCollider2D>().points = currentBlockData.polygon.points;

        buildAble = true;
        blockSelected = true;
    }

    public void ChangeBlock(int takedNum)
    {
        //selectBlock = takedNum;
        //tracingBlockSpr.sprite = buildingBlocks[selectBlock].GetComponent<SpriteRenderer>().sprite;
        //tracingBlock.SetActive(true);
        //tracingBlockSpr.color = tracingBlockColors[0];
        //tracingBlock.GetComponent<PolygonCollider2D>().points = buildingBlocks[selectBlock].GetComponent<PolygonCollider2D>().points;
        //buildAble = true;
        //blockSelected = true;
    }

    private void Update()
    {
        if (blockSelected)
        {
            TracingBlock();
            if (Input.GetMouseButtonDown(0) && buildAble)
            {
                BuildBlock();
            }
        }
    }

    private void TracingBlock()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);
        tracingBlock.transform.position = mousePos;
    }

    private void BuildBlock()
    {
        PoolableMono block = PoolManager.Instance.Pop(currentBlockData.blockName);
        block.transform.position = mousePos;

        //Instantiate(buildingBlocks[selectBlock], mousePos, tracingBlock.transform.rotation);
        tracingBlock.SetActive(false);
        buildAble = true;
        blockSelected = false;

        block.transform.SetParent(StageManager.Instance.CurrentStageInfo.Parents);

        onBuildEvent?.Invoke();
    }
}
