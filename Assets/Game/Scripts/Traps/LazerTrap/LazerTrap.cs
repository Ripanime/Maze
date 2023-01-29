using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LazerTrap : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private GameManager manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag) 
        {
            Destroy(collision.gameObject);
            manager.OnGameLose();
        }
    }
}
