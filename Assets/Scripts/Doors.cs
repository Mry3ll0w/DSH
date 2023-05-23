using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Doors : MonoBehaviour
{
    public Animator door;
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
        }
        else
        {
            inReach = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
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
        door.SetBool("Open", true);
        door.SetBool("Closed", false);
        doorSound.Play();
        

    }

    void DoorCloses()
    {
        door.SetBool("Open", false);
        door.SetBool("Closed", true);
        
    }


}