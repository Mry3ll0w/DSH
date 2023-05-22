using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{

    public GameObject itemOB;
    public GameObject InvOB;
    public GameObject PickUpText;
    public AudioSource PickUpSound;

    public GameObject OBTrigger;


    public bool inReach;
    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        PickUpText.SetActive(false);
        InvOB.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            PickUpText.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            PickUpText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            itemOB.SetActive(false);
            PickUpSound.Play();
            InvOB.SetActive(true);

            if (itemOB.name == "objeto1")
                OBTrigger.SetActive(true);
            if (itemOB.name == "objeto2")
                OBTrigger.SetActive(true);
            if (itemOB.name == "objecto3")
                OBTrigger.SetActive(true);

            PickUpText.SetActive(false);
        }
    }
}
