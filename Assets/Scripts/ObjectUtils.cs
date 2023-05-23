using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUtils : MonoBehaviour
{
    public GameObject item;
    public AudioSource Drink;
    public AudioSource Switch;

    public Animator anim;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            item.SetActive(false);
            Drink.Play();

    }
}
