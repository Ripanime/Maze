using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private string playerString;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == playerString) 
        {
            manager.OnGameWin();
        }
    }
}
