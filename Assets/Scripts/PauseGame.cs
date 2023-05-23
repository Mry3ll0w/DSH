﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject menu;
    public GameObject resume;
    public GameObject quit;
    private GameObject mainMenu;

    public bool on;
    public bool off;

    void Start()
    {
        mainMenu = GameObject.Find("MainMenuCanvas");
        menu.SetActive(false);
        off = true;
        on = false;
    }




    void Update()
    {
        if (off && Input.GetButtonDown("pause"))
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            off = false;
            on = true;
        }

        else if (on && Input.GetButtonDown("pause"))
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            off = true;
            on = false;
        }
        
    }

    public void Resume()
    {
            Time.timeScale = 1;
            menu.SetActive(false);
            off = true;
            on = false;

    }

    public void Exit()
    {
        Debug.Log("App Has Exited");
        Application.Quit();
    }
}
