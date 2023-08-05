using UnityEngine;

public class TWaterPump : MonoBehaviour
{
    [SerializeField] Transform pumpingTrm;
    [SerializeField] float interval;
    [SerializeField] float speed;

    private WaterPump pump;

    private void Awake()
    {
        pump = GetComponent<WaterPump>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            pump.SplashWater(Random.Range(10, 15), pumpingTrm.position, -pumpingTrm.position.normalized * speed, interval);
        }
    }
}
