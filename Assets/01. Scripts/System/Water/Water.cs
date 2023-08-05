using UnityEngine;

public class Water : PoolableMono
{
    private Rigidbody2D rb2d = null;
    private ConstantForce2D constantForce = null;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        constantForce = GetComponent<ConstantForce2D>();
    }

    public void Initialize(Vector2 forceDir)
    {
        constantForce.force = forceDir;
    }

    public override void Init()
    {
        constantForce.force = Vector2.zero;
    }
}
