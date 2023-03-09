using UnityEngine;
using TMPro;

public class TextRemainingUse : MonoBehaviour
{
    [SerializeField] private BonusType bonusType;
    private void Awake()
    {
        EventManager.OnRemainingUseChange.AddListener((BonusType type, int remUse) =>
        {
            if (type == bonusType)
            {
                GetComponent<TextMeshProUGUI>().text = remUse.ToString();
            }
        });
    }
    private void OnDestroy()
    {
        EventManager.OnRemainingUseChange.RemoveListener((BonusType type, int remUse) =>
        {
            if (type == bonusType)
            {
                GetComponent<TextMeshProUGUI>().text = remUse.ToString();
            }
        });
    }
}
