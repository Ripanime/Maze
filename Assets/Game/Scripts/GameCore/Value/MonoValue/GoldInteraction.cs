using UnityEngine;
using ValueBase;
public class GoldInteraction : MonoBehaviour
{
    [SerializeField] private InteractionType interactionType;
    [SerializeField] private GoldData goldData;
    private ValueInteraction valueInteraction;
    private int goldNumber;
    private void Awake()
    {
        valueInteraction = new ValueInteraction(interactionType, goldData.MinNumberOfValue, goldData.MaxNumberOfValue);
    }
    public void InitialiseEventForTextGold()
    {
        EventManager.SendGoldChanged(goldData.NumberOfValue);
    }
    public void Interaction(int val) 
    {
        goldNumber = valueInteraction.Interaction(val, goldData.NumberOfValue);
        if (!valueInteraction.isInteractionFalse) 
        {
            goldData.NumberOfValue = goldNumber;
            EventManager.SendGoldChanged(goldData.NumberOfValue);
        }
    }
}
