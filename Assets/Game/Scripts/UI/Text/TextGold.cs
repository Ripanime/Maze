using UnityEngine;
using TMPro;

public class TextGold : MonoBehaviour
{
    [SerializeField] private string additionalText;
    private void Awake()
    {
        EventManager.OnGoldChange.AddListener((int remValue) =>
        {
            GetComponent<TextMeshProUGUI>().text = remValue + additionalText;
        });
    }
    private void OnDestroy()
    {
        EventManager.OnGoldChange.RemoveListener((int remValue) =>
        {
            GetComponent<TextMeshProUGUI>().text = remValue + additionalText;
        });
    }
}
