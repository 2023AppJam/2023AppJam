using UnityEngine;

public class TWater : MonoBehaviour
{
    [SerializeField] Vector2 moveDir;
    [SerializeField] float speed;

    private Vector2 velocity;

    private void FixedUpdate()
    {
        velocity += moveDir * Time.fixedDeltaTime * speed;
        transform.Translate(velocity * Time.fixedDeltaTime, Space.World);
    }
}
