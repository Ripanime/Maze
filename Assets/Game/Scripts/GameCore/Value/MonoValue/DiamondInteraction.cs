using UnityEngine;
using ValueBase;

public class DiamondInteraction : MonoBehaviour
{
    [SerializeField] private InteractionType interactionType;
    [SerializeField] private DiamondData diamondData;
    private ValueInteraction valueInteraction;
    private int diamondNumber;
    private void Awake()
    {
        valueInteraction = new ValueInteraction(interactionType,diamondData.MinNumberOfValue, diamondData.MaxNumberOfValue);
    }
    public void InitialiseEventForTextDiamond()
    {
        EventManager.SendDiamondChanged(diamondData.NumberOfValue);
    }
    public void Interaction(int val)
    {
        diamondNumber = valueInteraction.Interaction(val, diamondData.NumberOfValue);
        if (!valueInteraction.isInteractionFalse) 
        {
            diamondData.NumberOfValue = diamondNumber;
            EventManager.SendDiamondChanged(diamondData.NumberOfValue);
        }
    }
}
