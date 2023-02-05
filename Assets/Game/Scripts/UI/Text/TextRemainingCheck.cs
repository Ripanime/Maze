using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextRemainingCheck : MonoBehaviour
{
    [SerializeField] private string TextForRemainingChecks;
    private void Awake()
    {
        EventManager.OnCheckPressed.AddListener((int remChecks) =>
        {
            GetComponent<TextMeshProUGUI>().text = remChecks + TextForRemainingChecks;
        });
    }
    private void OnDestroy()
    {
        EventManager.OnCheckPressed.RemoveListener((int remChecks) =>
        {
            GetComponent<TextMeshProUGUI>().text = remChecks + TextForRemainingChecks;
        });
    }
}
