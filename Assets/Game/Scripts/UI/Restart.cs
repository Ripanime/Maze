using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private GameObject state;
    public void RestartTheGame() 
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        state.SetActive(false);
    }
}
