using UnityEngine;
using UnityEngine.Events;

public class Block : PoolableMono, IDamageable
{
    [SerializeField] BlockDataSO blockData;
    [SerializeField] UnityEvent onDestoryEvent;

    public float hp;

    private void Awake()
    {
        //Init();
    }

    private void Update()
    {
        //if (hp <= 0)
        //    return;

        Collider2D[] blocks = Physics2D.OverlapCircleAll(transform.position, 1f, blockData.targetLayer);
        foreach (Collider2D col in blocks)
            if (col.TryGetComponent<IDamageable>(out IDamageable id))
                id?.OnDamage(blockData.damage * Time.deltaTime);
    }

    public void OnDamage(float damage)
    {
        if (hp <= 0)
            return;

        hp -= damage;

        if (hp <= 0f)
            DestroyEvent();
    }

    public void PushThis()
    {
        PoolManager.Instance.Push(this);
    }

    private void DestroyEvent()
    {
        onDestoryEvent?.Invoke();
        //Destroy(gameObject);
    }

    public override void Init()
    {
        hp = blockData.maxHP;
    }
}