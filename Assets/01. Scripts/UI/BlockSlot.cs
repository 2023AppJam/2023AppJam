using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSlot : MonoBehaviour
{
    [SerializeField] List<Image> blockImages;
    [SerializeField] List<Text> blockTexts;
    [SerializeField] Sprite emptySprite;
    private List<BlockQuantity> blocks;

    public void SetBlocks(List<BlockQuantity> blocks)
    {
        this.blocks = blocks;

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
}
