using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private LevelFinish levelFinish;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController playerController) && levelFinish.IsCompleted()) 
        {
            manager.OnGameWin();
        }
    }
}
