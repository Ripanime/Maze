using UnityEngine;
using TMPro;

public enum ValueType 
{
    Gold,
    Diamond
}
public class TextValue : MonoBehaviour
{
    [SerializeField] private ValueType valueType;
    [SerializeField] private string additionalText;
    [SerializeField] private SceneGold sceneGold;
    [SerializeField] private SceneDiamond sceneDiamond;
    private TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (this.gameObject.activeInHierarchy) 
        {
            switch (valueType)
            {
                case ValueType.Gold:
                    text.text = sceneGold.numberOfValue + additionalText;
                    break;
                case ValueType.Diamond:
                    text.text = sceneDiamond.numberOfValue + additionalText;
                    break;
            }
        }
    }
}
