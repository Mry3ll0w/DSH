using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;

    public GameObject Ob1;
    public GameObject Ob2;
    public GameObject Ob3;
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetButtonDown("1"))
        {
            Ob1.SetActive(false);
            Ob2.SetActive(false);
            Ob3.SetActive(false);
            
        }

        if (Input.GetButtonDown("2") && target1.activeSelf)
        {
            Ob1.SetActive(true);
            Ob2.SetActive(false);
            Ob3.SetActive(false);
            
        }
        
        if (Input.GetButtonDown("3") && target2.activeSelf)
        {
            Ob1.SetActive(false);
            Ob2.SetActive(true);
            Ob3.SetActive(false);
        }
        
        if (Input.GetButtonDown("4") && target3.activeSelf)
        {
            Ob1.SetActive(false);
            Ob2.SetActive(false);
            Ob3.SetActive(true);
        }
        
    }
}
