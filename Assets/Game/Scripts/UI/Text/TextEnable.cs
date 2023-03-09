using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextEnable : MonoBehaviour
{
    [SerializeField] private float timeToAppear;
    [SerializeField] private TextMeshProUGUI text;
    private float timeToDisopear;

    public void EnableText()
    {
        text.enabled = true;
        timeToDisopear = Time.time + timeToAppear;
    }
    void Update()
    {
        if(text.enabled && (Time.time >= timeToDisopear)) 
        {
            text.enabled = false;
        }
    }
}
