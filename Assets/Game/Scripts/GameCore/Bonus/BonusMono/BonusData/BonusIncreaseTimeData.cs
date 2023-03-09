using UnityEngine;
[CreateAssetMenu(fileName = "new BonusIncreaseTimeData", menuName = "BonusIncreaseTimeData", order = 58)]
public class BonusIncreaseTimeData : ScriptableObject
{
    [SerializeField] private float increaseTime;
    public float IncreaseTime => increaseTime;

    [SerializeField] private int minRemainingUse;
    public int MinRemainingUse => minRemainingUse;

    [SerializeField] private int maxRemainingUse;
    public int MaxRemainingUse => maxRemainingUse;
}
