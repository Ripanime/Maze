using UnityEngine;
using Value;

public class SceneDiamondInteraction : MonoBehaviour
{
    [SerializeField] private InteractionValueType valueType;
    [SerializeField] private SceneDiamond sceneDiamond;
    private Diamond diamond;
    private int numberValue;
    private void Awake()
    {
        diamond = new Diamond();
    }
    public void Interaction(int value)
    {
        numberValue = 0;
        switch (valueType)
        {
            case InteractionValueType.Add:
                numberValue = diamond.Buy(value,sceneDiamond.numberOfValue,sceneDiamond.minNumberOfValue,sceneDiamond.maxNumberOfValue);
                sceneDiamond.numberOfValue = numberValue;
                break;
            case InteractionValueType.Remove:
                numberValue = diamond.Sell(value,sceneDiamond.numberOfValue,sceneDiamond.minNumberOfValue,sceneDiamond.maxNumberOfValue);
                sceneDiamond.numberOfValue = numberValue;
                break;
        }
    }
}
