using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    public GameObject object01;
    public GameObject object02;
    public GameObject object03;
    public GameObject object01Trigger;
    public GameObject object02Trigger;
    public GameObject object03Trigger;

    void Start()
    {
        object01Trigger.SetActive(false);
        object02Trigger.SetActive(false);
        object03Trigger.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("1"))
        {
            object01.SetActive(false);
            object02.SetActive(false);
            object03.SetActive(false);
        }

        if (Input.GetButtonDown("2") && object01Trigger.activeSelf)
        {
            object01.SetActive(true);
            object02.SetActive(false);
            object03.SetActive(false);
        }

        if (Input.GetButtonDown("3") && object02Trigger.activeSelf)
        {
            object01.SetActive(false);
            object02.SetActive(true);
            object03.SetActive(false);
        }
        
        if (Input.GetButtonDown("4") && object03Trigger.activeSelf)
        {
            object01.SetActive(false);
            object02.SetActive(false);
            object03.SetActive(true);
        }
    }
}
