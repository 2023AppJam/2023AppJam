using UnityEngine;

public class BlockButton : MonoBehaviour
{
    private BlockSlot slot;
    private BlockBuilder builder;

    public void SelectBlock(int index)
    {
        if(slot == null)
            slot = GameManager.Instance.Slot;
        if(builder == null)
            builder = GameManager.Instance.BlockBuilder;

        if(slot.Blocks[index].quantity > 0)
            builder.ChangeBlock(slot.Blocks[index].block, () => slot.UseBlock(index));

        AudioManager.Instance.PlaySystem("ButtonClick");
    }
}
