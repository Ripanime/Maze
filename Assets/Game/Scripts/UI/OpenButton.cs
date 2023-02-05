using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class OpenButton : MonoBehaviour
{
    [SerializeField] private string buttonDownAnim;
    [SerializeField] private string buttonUpAnim;
    [SerializeField] private GameObject state;
    [SerializeField] private GameManager manager;
    private Animator anim;
    private bool gamePauseIsActive;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnClick()
    {
        gamePauseIsActive = !state.activeInHierarchy;
        if(state.activeInHierarchy == true) 
        {
            anim.SetTrigger(buttonDownAnim);
            state.SetActive(gamePauseIsActive);
            manager.OnGamePause(gamePauseIsActive);
        }
        else 
        {
            anim.SetTrigger(buttonUpAnim);
            state.SetActive(gamePauseIsActive);
            manager.OnGamePause(gamePauseIsActive);
        }
    }
}
