using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NotArrowTrapScript : MonoBehaviour
{
    [SerializeField] private GameObject lazer;
    [SerializeField] private string playerTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag)) 
        {
            Destroy(lazer);
            Destroy(this.gameObject);
        }
    }
}
