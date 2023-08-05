using UnityEngine;

public class Water : PoolableMono
{
    private Rigidbody2D rb2d = null;
    private ConstantForce2D constantForce2d = null;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        constantForce2d = GetComponent<ConstantForce2D>();
    }

    public void Initialize(Vector2 forceDir)
    {
        Vector2 force = forceDir + new Vector2(0, 9.81f);
        constantForce2d.force = force;
    }

    public override void Init()
    {
        constantForce2d.force = Vector2.zero;
    }
}
