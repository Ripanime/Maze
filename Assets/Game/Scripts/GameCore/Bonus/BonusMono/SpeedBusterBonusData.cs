using UnityEngine;
[CreateAssetMenu(fileName = "new SpeedBusterBonusData", menuName = "SpeedBusterBonusData", order = 53)]
public class SpeedBusterBonusData : ScriptableObject
{
    [SerializeField] private int durationTime;
    public int DurationTime => durationTime;

    [SerializeField] private int multiplier;
    public int Multiplier => multiplier;

    public int RemainingUse;
}
