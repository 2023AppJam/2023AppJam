using UnityEngine;

public class WWWater : MonoBehaviour
{
    private void Update()
    {
        Collider2D[] blocks = Physics2D.OverlapCircleAll(transform.position, 1f, 1 << 7);
        foreach (Collider2D col in blocks)
            if (col.TryGetComponent<IDamageable>(out IDamageable id))
                id?.OnDamage(1f * Time.deltaTime);
    }
}
