[System.Serializable]
public struct BlockQuantity
{
    public BlockDataSO block;
    public int quantity;

    public BlockQuantity(BlockDataSO block, int quantity)
    {
        this.block = block;
        this.quantity = quantity;
    }
}
