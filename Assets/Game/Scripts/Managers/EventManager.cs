using UnityEngine;
using UnityEngine.Events;
public class EventManager : MonoBehaviour
{
    public static UnityEvent<int> OnCheckPressed = new UnityEvent<int>();
    public static UnityEvent<int> OnGoldChange = new UnityEvent<int>();
    public static UnityEvent<int> OnDiamondChange = new UnityEvent<int>();
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
}
