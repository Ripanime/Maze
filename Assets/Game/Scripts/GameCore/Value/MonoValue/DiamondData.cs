using UnityEngine;
[CreateAssetMenu(fileName = "new DiamondData", menuName = "DiamondData", order = 55)]
public class DiamondData : ScriptableObject
{
    public int NumberOfValue;
    [SerializeField] private int maxNumberOfValue;
    public int MaxNumberOfValue => maxNumberOfValue;

    [SerializeField] private int minNumberOfValue;
    public int MinNumberOfValue => minNumberOfValue;    
}
