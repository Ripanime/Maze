using UnityEngine;
using UnityEngine.Events;

public enum BonusType
{
    SpeedBuster,
    IncreaseTime,
    GoThroughWall,
    //Dis == distance
    DestroyTrapCertainDis,
    DestroyAllTrap,
    SuggestWay,
    //Tp == teleport
    TpToEnd
}
public class EventManager : MonoBehaviour
{
    public static UnityEvent<int> OnCheckPressed = new UnityEvent<int>();
    public static UnityEvent<int> OnGoldChange = new UnityEvent<int>();
    public static UnityEvent<int> OnDiamondChange = new UnityEvent<int>();
    public static UnityEvent<BonusType,int> OnRemainingUseChange = new UnityEvent<BonusType,int>();
    public static void SendCheckPressed(int remChecks) 
    {
        OnCheckPressed.Invoke(remChecks);
    }
    public static void SendGoldChanged(int remGold) 
    {
        OnGoldChange.Invoke(remGold);
    }
    public static void SendDiamondChanged(int remDiamond)
    {
        OnDiamondChange.Invoke(remDiamond);
    }
    public static void SendRemainingUseChange(BonusType type,int remUse) 
    {
        OnRemainingUseChange.Invoke(type, remUse);
    }
}