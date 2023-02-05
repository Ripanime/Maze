using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Saw : MonoBehaviour
{
    [SerializeField] private SawData sawData;
    [SerializeField] private GameManager manager;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == sawData.PlayerTag)
        {
            manager.OnGameLose();
        }
    }
    private void Update()
    {
        anim.SetBool("IsSawing",true);
    }
    private void OnDisable()
    {
        anim.SetBool("IsSawing", false);
    }
}
