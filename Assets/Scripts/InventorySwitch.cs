using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public AudioSource switchSound;

    public GameObject Ob1;
    public GameObject Ob2;
    public GameObject Ob3;
    void Start()
    {
 
    }

    void Update()
    {
        target1 = GameObject.FindWithTag("can1");
        target2 = GameObject.FindWithTag("can2");
        target3 = GameObject.FindWithTag("can3");

        if (Input.GetButtonDown("1"))
        {
            Ob1.SetActive(false);
            Ob2.SetActive(false);
            Ob3.SetActive(false);
        }

        if (Input.GetButtonDown("2") && target1 != null)
        {
            Debug.Log("1: " + target1.activeSelf);
            switchSound.Play();
            Ob1.SetActive(true);
            Ob2.SetActive(false);
            Ob3.SetActive(false);
            
        }
        
        if (Input.GetButtonDown("3") && target2 != null)
        {
            Debug.Log("2: " + target2.activeSelf);
            switchSound.Play();
            Ob1.SetActive(false);
            Ob2.SetActive(true);
            Ob3.SetActive(false);
        }
        
        if (Input.GetButtonDown("4") && target3 != null)
        {
            Debug.Log("3: " + target3.activeSelf);
            switchSound.Play();
            Ob1.SetActive(false);
            Ob2.SetActive(false);
            Ob3.SetActive(true);
        }
        
    }
}
