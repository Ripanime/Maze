using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextEnable : MonoBehaviour
{
    [SerializeField] private float timeToAppear;
    private float timeToDisopear;
    private TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

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
