using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BonusOff : MonoBehaviour
{
    private static Image[] images;
    private static TextMeshProUGUI[] texts;
    void Start()
    {
        images = GetComponentsInChildren<Image>();
        texts = GetComponentsInChildren<TextMeshProUGUI>();
    }
    public static void BonusSwitch(bool activate) 
    {
        foreach (var text in texts)
        {
            text.enabled = activate;
        }
        foreach (var image in images) 
        {
            image.enabled = activate;
        }
    }
}
