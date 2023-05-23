using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class StartingScreen : MonoBehaviour
{
    private GameObject player;
    private GameObject hud;
    public GameObject startingScreen;

    public float waitTime;


    void Start()
    {
        startingScreen.SetActive(true);
        player = GameObject.FindWithTag("Player");
        //hud = GameObject.FindWithTag("HUD");
        player.GetComponent<FirstPersonController>().enabled = false;
        //hud.SetActive(false);

        StartCoroutine(Starting());
    }

    IEnumerator Starting()
    {
        yield return new WaitForSeconds(waitTime);
        startingScreen.SetActive(false);
        player.GetComponent<FirstPersonController>().enabled = true;
        //hud.SetActive(true);
    }




    void Update()
    {
        
    }
}
