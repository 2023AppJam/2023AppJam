using System.Collections;
using UnityEngine;

public class StageInformation : PoolableMono
{
    [SerializeField] StageDataSO stageData;
    public StageDataSO StageData => stageData;

    [SerializeField] AudioClip clip;
    private AudioSource source;

    private WaterPump pump;
    private Transform arrows;
    private Block village;

    private Transform parents = null;
    public Transform Parents => parents;

    private bool started = false;
    private float timer = 0f;

    private void Awake()
    {
        pump = GetComponent<WaterPump>();
        source = GetComponent<AudioSource>();
        arrows = transform.Find("Arrows");
        parents = transform.Find("Parents");

        village = GetComponentInChildren<Block>();
    }

    private void Update()
    {
        if (started == false)
            return;

        timer += Time.deltaTime;
        GameManager.Instance.RemainText.text = $"남은 시간 : {(int)(stageData.runningTime - timer)}";

        if(timer >= stageData.runningTime)
        {
            // 게임 클리어
            Init();
            StageManager.Instance.ClearStage();
        }
    }

    public void DefeatStage()
    {
        if(started)
        {
            started = false;
            GameManager.Instance.InGamePanel.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public override void Init()
    {
        GameManager.Instance.RemainText.text = "";
        started = false;
        StopAllCoroutines();
        arrows.gameObject.SetActive(true);

        while(parents.childCount > 0)
        {
            if (parents.GetChild(0).TryGetComponent<PoolableMono>(out PoolableMono obj))
                PoolManager.Instance.Push(obj);

        }

        timer = 0f;
        //pump.Init();
    }

    public void StartSequence()
    {
        started = true;
        village.Init();
        arrows.gameObject.SetActive(false);
        StartCoroutine(SequenceCoroutine());
    }

    private IEnumerator SequenceCoroutine()
    {
        foreach(PumpSequence sequence in stageData.pumpSequence)
        {
            yield return new WaitForSeconds(sequence.delay);
            pump.SplashWater(sequence.count, sequence.pos, sequence.dir, sequence.interval);
            source.PlayOneShot(clip);
        }
    }
}
