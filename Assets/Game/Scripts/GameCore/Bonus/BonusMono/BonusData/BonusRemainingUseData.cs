using UnityEngine;
/// <summary>
/// All fields are public, use correctly
/// </summary>
[CreateAssetMenu(fileName = "new BonusRemainingUseData", menuName = "BonusRemainingUseData", order = 57)]
public class BonusRemainingUseData : ScriptableObject
{
    public int SpeedBusterRemUse;
    public int IncreaseTimeRemUse;
    public int GoThroughWallRemUse;
    public int DestroyTrapCertainDistanceRemUse;
    public int DestroyAllTrapRemUse;
    public int SuggestWay;
    public int TpToEnd;
} 
