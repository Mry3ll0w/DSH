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

    private void Start()
    {
        StartCoroutine(ManageTexts());
    }

    IEnumerator ManageTexts()
    {
        yield return new WaitForSeconds(9);
        text1.SetActive(true);
        text1.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(timer);
        Destroy(text1);

        text2.SetActive(true);
        text2.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(timer);
        Destroy(text2);

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
