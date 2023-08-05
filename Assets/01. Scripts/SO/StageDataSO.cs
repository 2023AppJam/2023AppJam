using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/StageData")]
public class StageDataSO : ScriptableObject
{
    public List<BlockQuantity> blockList;
    public List<PumpSequence> pumpSequence;
    public float runningTime;
}
