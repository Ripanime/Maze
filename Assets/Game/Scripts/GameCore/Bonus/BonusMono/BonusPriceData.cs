using UnityEngine;

[CreateAssetMenu(fileName = "new BonusPriceData", menuName = "BonusPriceData", order = 53)]
public class BonusPriceData : ScriptableObject
{
    [SerializeField] private int speedBuster;
    public int SpeedBuster => speedBuster;

    [SerializeField] private int increaseTime;
    public int IncreaseTime => increaseTime;

    [SerializeField] private int goThroughWall;
    public int GoThroughWall => goThroughWall;

    //Dis == Distance
    [SerializeField] private int destroyTrapCertainDis;
    public int DestroyTrapCertainDis => destroyTrapCertainDis;

    [SerializeField] private int destroyAllTrap;
    public int DestroyAllTrap => destroyAllTrap;

    [SerializeField] private int suggestWay;
    public int SuggestWay => suggestWay;

    //tp == teleport
    [SerializeField] private int tpToEnd;
    public int TpToEnd => tpToEnd;
}
