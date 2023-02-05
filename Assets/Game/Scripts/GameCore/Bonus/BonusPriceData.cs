using UnityEngine;

[CreateAssetMenu(fileName = "new BonusPriceData", menuName = "BonusPriceData", order = 53)]
public class BonusPriceData : ScriptableObject
{
    [SerializeField] private float plusMoveSpeed;
    public float PlusMoveSpeed => plusMoveSpeed;

    [SerializeField] private float increaseTime;
    public float IncreaseTime => increaseTime;

    [SerializeField] private float goThroughWall;
    public float GoThroughWall => goThroughWall;

    //Dis == Distance
    [SerializeField] private float destroyTrapCertainDis;
    public float DestroyTrapCertainDis => destroyTrapCertainDis;

    [SerializeField] private float destroyAllTrap;
    public float DestroyAllTrap => destroyAllTrap;

    [SerializeField] private float suggestWay;
    public float SuggestWay => suggestWay;

    //tp == teleport
    [SerializeField] private float tpToEnd;
    public float TpToEnd => tpToEnd;
}
