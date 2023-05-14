using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Doors : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject closeText;
    public AudioSource doorSound;

    public bool inReach;




    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && door.GetBool("Open") != true)
        {
            inReach = true;
            openText.SetActive(true);
        }
        else
        {
            inReach = true;
            closeText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            closeText.SetActive(false);
        }
    }

    void Update()
    {

        if (inReach && door.GetBool("Open") != true && Input.GetKeyDown(KeyCode.E))
        {
            DoorOpens();
        }
        
        else if (door.GetBool("Open") == true && Input.GetKeyDown(KeyCode.E))
        {
            DoorCloses();
        }
        



    }
    void DoorOpens()
    {
        Debug.Log("It Opens");
        
        door.SetBool("Open", true);
        door.SetBool("Closed", false);
        //doorSound.Play();
        

    }

    void DoorCloses()
    {
        Debug.Log("It Closes");
        door.SetBool("Open", false);
        door.SetBool("Closed", true);
        
    }


}