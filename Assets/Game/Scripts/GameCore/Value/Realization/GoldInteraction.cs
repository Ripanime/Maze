using UnityEngine;
using ValueBase;

public class GoldInteraction : MonoBehaviour
{
    [SerializeField] private InteractionType interactionType;
    [SerializeField] private SceneGold sceneGold;
    private ValueInteraction valueInteraction;
    private int goldNumber;
    private void Awake()
    {
        valueInteraction = new ValueInteraction(interactionType,sceneGold.MaxNumberOfValue,sceneGold.MinNumberOfValue);
    }
    public void InitialiseEventForTextGold() 
    {
        EventManager.SendGoldChanged(sceneGold.NumberOfValue);
    }
    public void Interaction(int val) 
    {
        goldNumber = valueInteraction.Interaction(val,sceneGold.NumberOfValue);
        if(goldNumber != int.MinValue) 
        {
            sceneGold.NumberOfValue = goldNumber;
            EventManager.SendGoldChanged(sceneGold.NumberOfValue);
        }
    }
}
