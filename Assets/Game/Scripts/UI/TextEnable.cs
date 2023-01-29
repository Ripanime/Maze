using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextEnable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float timeToAppear;
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
