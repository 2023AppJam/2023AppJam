using UnityEngine;

public class Block : MonoBehaviour, IBlock
{
    [SerializeField] BlockDataSO blockData;

    public void OnDamage(float damage)
    {
    }
}