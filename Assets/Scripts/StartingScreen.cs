using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class StartingScreen : MonoBehaviour
{
    private GameObject player;
    public GameObject startingScreen;

    public float waitTime;


    void Start()
    {
        startingScreen.SetActive(true);
        player = GameObject.FindWithTag("Player");
        player.GetComponent<FirstPersonController>().enabled = false;

        StartCoroutine(Starting());
    }

    IEnumerator Starting()
    {
        yield return new WaitForSeconds(waitTime);
        startingScreen.SetActive(false);
        player.GetComponent<FirstPersonController>().enabled = true;

    }




    void Update()
    {
        
    }
}
