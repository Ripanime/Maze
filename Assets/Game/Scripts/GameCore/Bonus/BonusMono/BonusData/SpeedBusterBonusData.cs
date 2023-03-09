using UnityEngine;
[CreateAssetMenu(fileName = "new SpeedBusterBonusData", menuName = "SpeedBusterBonusData", order = 53)]
public class SpeedBusterBonusData : ScriptableObject
{
    [SerializeField] private int durationTime;
    public int DurationTime => durationTime;

    [SerializeField] private int multiplier;
    public int Multiplier => multiplier;

    [SerializeField] private int minRemainingUse;
    public int MinRemainingUse => minRemainingUse;

    [SerializeField] private int maxRemainingUse;
    public int MaxRemainingUse => maxRemainingUse;
}
