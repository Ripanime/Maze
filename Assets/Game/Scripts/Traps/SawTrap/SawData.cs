using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New SawData", menuName = "SawData", order = 51)]
public class SawData : ScriptableObject
{
    [SerializeField] private string playerTag;
    public string PlayerTag
    {
        get 
        {
            return playerTag;
        }
    }
}
