using UnityEngine;
using ValueBase;

public class DiamondInteraction : MonoBehaviour
{
    [SerializeField] private InteractionType interactionType;
    [SerializeField] private SceneDiamond sceneDiamond;
    private ValueInteraction valueInteraction;
    private int diamondNumber;
    private void Awake()
    {
        valueInteraction = new ValueInteraction(interactionType, sceneDiamond.MaxNumberOfValue, sceneDiamond.MinNumberOfValue);
    }
    public void InitialiseEventForTextDiamond()
    {
        EventManager.SendDiamondChanged(sceneDiamond.NumberOfValue);
    }
    public void Interaction(int val)
    {
        diamondNumber = valueInteraction.Interaction(val,sceneDiamond.NumberOfValue);
        if(diamondNumber != int.MinValue) 
        {
            sceneDiamond.NumberOfValue = diamondNumber;
            EventManager.SendDiamondChanged(sceneDiamond.NumberOfValue);
        }
    }
}
