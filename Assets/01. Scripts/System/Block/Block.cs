using UnityEngine;
using UnityEngine.Events;

public class Block : PoolableMono, IDamageable
{
    [SerializeField] BlockDataSO blockData;
    [SerializeField] UnityEvent onDestoryEvnet;

    private float hp;

    private void Awake()
    {
        //Init();
    }

    private void Update()
    {
        Collider2D[] blocks = Physics2D.OverlapCircleAll(transform.position, 1f, blockData.targetLayer);
        foreach (Collider2D col in blocks)
            if (col.TryGetComponent<IDamageable>(out IDamageable id))
                id?.OnDamage(blockData.damage * Time.deltaTime);
    }

    public void OnDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0f)
            DestroyEvent();
    }

    private void DestroyEvent()
    {
        onDestoryEvnet?.Invoke();
        Destroy(gameObject);
    }

    public override void Init()
    {
        hp = blockData.maxHP;
    }
}