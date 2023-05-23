using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUtils : MonoBehaviour
{
    public GameObject item;
    public AudioSource Drink;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;

    public DeathScript DeathScriptReference;

    public AudioSource shitpost;
    //Gestion de evento de teletransporte
    public delegate void SpeedUpEvent();
    public static event SpeedUpEvent OnSpeedUp;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        target1 = GameObject.FindWithTag("can1");
        target2 = GameObject.FindWithTag("can2");
        target3 = GameObject.FindWithTag("can3");


        if (Input.GetMouseButtonDown(0) && target1 != null)
        {
            item.SetActive(false);
            Drink.Play();
            Destroy(target1);

        }
        else if (Input.GetMouseButtonDown(0) && target2 != null)
        {
            item.SetActive(false);
            Destroy(target2);
            DeathScriptReference.DrinkDeath();

        }
        else if (Input.GetMouseButtonDown(0) && target3 != null)
        {
            item.SetActive(false);
            Drink.Play();
            shitpost.Play();
            Destroy(target3);
        }
    }
}
