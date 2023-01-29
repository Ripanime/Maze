using UnityEngine;
using Value;
public enum InteractionValueType 
{
    Add,
    Remove
}
public class SceneGoldInteraction : MonoBehaviour
{
    [SerializeField] private InteractionValueType valueType;
    [SerializeField] private SceneGold sceneGold;
    private int numberValue;
    private Gold gold;
    private void Awake()
    {
        gold = new Gold();
    }
    public void Interaction(int value)
    {
        numberValue = 0;
        switch (valueType)
        {
            case InteractionValueType.Add:
                numberValue = gold.Buy(value, sceneGold.numberOfValue, sceneGold.minNumberOfValue, sceneGold.maxNumberOfValue);
                sceneGold.numberOfValue = numberValue;
                break;
            case InteractionValueType.Remove:
                numberValue = gold.Sell(value, sceneGold.numberOfValue, sceneGold.minNumberOfValue, sceneGold.maxNumberOfValue);
                sceneGold.numberOfValue = numberValue;
                break;
        }
    }
}
