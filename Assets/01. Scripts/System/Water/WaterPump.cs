using System.Collections;
using UnityEngine;

public class WaterPump : MonoBehaviour
{
    [SerializeField] float posFactor = 3f;
    [SerializeField] float intervalFactor = 0.1f;

    public void SplashWater(int count, Vector2 position, Vector2 dir, float interval = 0.1f)
    {
        StartCoroutine(SplashWaterCoroutine(count, position, dir, interval));
    }

    private IEnumerator SplashWaterCoroutine(int count, Vector2 pos, Vector2 dir, float interval = 0.1f)
    {
        for(int i = 0; i < count; i++)
        {
            Vector2 spawnPos = Random.insideUnitCircle * posFactor + pos;

            Water water = PoolManager.Instance.Pop("Water") as Water;
            water.transform.position = spawnPos;
            water.Initialize(dir);

            float inter = Random.Range(interval - intervalFactor, interval + intervalFactor);
            yield return new WaitForSeconds(Mathf.Max(0, inter));
        }
    }
}