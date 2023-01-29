using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OpenButton : MonoBehaviour
{
    [SerializeField] private string ButtonDownAnim;
    [SerializeField] private string ButtonUpAnim;
    [SerializeField] private GameObject GamePause;
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameManager manager;
    private Animator anim;
    private bool gamePauseIsActive;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnClick()
    {
        gamePauseIsActive = !GamePause.activeInHierarchy;
        if(GamePause.activeInHierarchy == true) 
        {
            anim.SetTrigger(ButtonDownAnim);
            GamePause.SetActive(gamePauseIsActive);
            manager.OnGamePause(gamePauseIsActive);
        }
        else 
        {
            anim.SetTrigger(ButtonUpAnim);
            GamePause.SetActive(gamePauseIsActive);
            manager.OnGamePause(gamePauseIsActive);
        }
        if (Shop.activeInHierarchy == true)
        {
            anim.SetTrigger(ButtonDownAnim);
            Shop.SetActive(!Shop.activeInHierarchy);
            manager.OnGamePause(Shop.activeInHierarchy);
        }
        if (Settings.activeInHierarchy == true)
        {
            anim.SetTrigger(ButtonDownAnim);
            Settings.SetActive(!Settings.activeInHierarchy);
            manager.OnGamePause(Settings.activeInHierarchy);
        }
    }
}
