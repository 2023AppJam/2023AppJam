using UnityEngine;

[CreateAssetMenu(menuName = "SO/BlockData")]
public class BlockDataSO : ScriptableObject
{
    public LayerMask targetLayer;
    public float maxHP;
    public float damage;
}
