using UnityEngine;

[CreateAssetMenu(menuName = "SO/BlockData")]
public class BlockDataSO : ScriptableObject
{
    public LayerMask targetLayer;
    public Sprite blockSprite;
    public PolygonCollider2D polygon;
    public string blockName;
    public float maxHP;
    public float damage;
}
