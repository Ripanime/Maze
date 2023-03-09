using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class BonusBuyCall : MonoBehaviour
{
    [SerializeField] private UnityEvent onBonusBuy;
    public void BuyBonus()
    {
        onBonusBuy.Invoke();
    }
}
