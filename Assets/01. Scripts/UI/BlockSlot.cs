using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSlot : MonoBehaviour
{
    [SerializeField] List<Image> blockImages;
    [SerializeField] List<Text> blockTexts;
    [SerializeField] Sprite emptySprite;
    private List<BlockQuantity> blocks;
    public List<BlockQuantity> Blocks => blocks;

    public void SetBlocks(List<BlockQuantity> blocks)
    {
        this.blocks = new List<BlockQuantity>(blocks);

        for(int i = 0; i < blockImages.Count; i++)
        {
            if (this.blocks.Count > i)
            {
                blockImages[i].sprite = this.blocks[i].block.blockSprite;
                blockTexts[i].text = this.blocks[i].quantity.ToString();
            }
            else
            {
                blockImages[i].sprite = emptySprite;
                blockTexts[i].text = "0";
            }
        }
    }

    public void UseBlock(int index)
    {
        blocks[index] = new BlockQuantity(blocks[index].block, blocks[index].quantity - 1);
        blockTexts[index].text = blocks[index].quantity.ToString();
    }
}
