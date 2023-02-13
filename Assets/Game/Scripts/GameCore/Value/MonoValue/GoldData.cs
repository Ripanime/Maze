using UnityEngine;
[CreateAssetMenu(fileName = "GoldData", menuName = "GoldData", order = 56)]
public class GoldData : ScriptableObject
{
    public int NumberOfValue;
    [SerializeField] private int maxNumberOfValue;
    public int MaxNumberOfValue => maxNumberOfValue;

    [SerializeField] private int minNumberOfValue;
    public int MinNumberOfValue => minNumberOfValue;
}
