using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudManager : MonoBehaviour

{
    public TMP_Text time;
    public GameObject text1;
    public GameObject text2;
    float timer = 4.0f;
    //public TMP_Text month; Por si se quiere cambiar el texto de abajo, aunque en principio
    //public TMP_Text year;  cada mapa tiene su timestamp.
    float gameTime = 0.0f;
    int randomNumber;

    public AudioSource audio1, audio2, audio3, audio4, audio5, audio6, audio7;

    private void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        StartCoroutine(ManageTexts());
        StartCoroutine(ManageAudios());
    }
    IEnumerator ManageAudios()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            randomNumber = Random.Range(0, 6);
            switch (randomNumber)
            {
                case 0: audio1.Play(); break;
                case 1: audio2.Play(); break;
                case 2: audio3.Play(); break;
                case 3: audio4.Play(); break;
                case 4: audio5.Play(); break;
                case 5: audio6.Play(); break;
                case 6: audio7.Play(); break;
            }
        }
    }
    IEnumerator ManageTexts()
    {
        yield return new WaitForSeconds(9);
        text1.SetActive(true);
        text1.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(timer);

        text2.SetActive(true);
        text2.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(timer);

    }

    void Update()
    {

        gameTime += Time.deltaTime;
        int hours = Mathf.FloorToInt(gameTime / 3600);  //horas
        int minutes = Mathf.FloorToInt(gameTime / 60);  //minutos
        int seconds = Mathf.FloorToInt(gameTime % 60);  //segundos
        time.text = "PM  " + string.Format("{0:0}:{1:00}:{2:00}",hours, minutes, seconds); //formato 0:00:00
    }
}
