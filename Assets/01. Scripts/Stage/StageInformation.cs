using System.Collections;
using UnityEngine;

public class StageInformation : PoolableMono
{
    [SerializeField] StageDataSO stageData;
    public StageDataSO StageData => stageData;

    private WaterPump pump;

    private void Awake()
    {
        //pump = transform.Find("WaterPump").GetComponent<WaterPump>();
    }

    public override void Init()
    {
        StopAllCoroutines();
    }

    public void StartSequence()
    {
        StartCoroutine(SequenceCoroutine());
    }

    private IEnumerator SequenceCoroutine()
    {
        foreach(PumpSequence sequence in stageData.pumpSequence)
        {
            yield return new WaitForSeconds(sequence.delay);
            pump.SplashWater(sequence.count, sequence.pos, sequence.dir, sequence.interval);
        }
    }
}
