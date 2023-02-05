using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextDiamond : MonoBehaviour
{
    [SerializeField] private string additionalText;
    private void Awake()
    {
        EventManager.OnDiamondChange.AddListener((int remValue) =>
        {
            GetComponent<TextMeshProUGUI>().text = remValue + additionalText;
        });
    }
    private void OnDestroy()
    {
        EventManager.OnDiamondChange.RemoveListener((int remValue) =>
        {
            GetComponent<TextMeshProUGUI>().text = remValue + additionalText;
        });
    }
}
