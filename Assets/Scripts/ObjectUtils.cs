using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUtils : MonoBehaviour
{
    public GameObject item;
    public AudioSource itemUse;

    void Start()
    {
        item.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
