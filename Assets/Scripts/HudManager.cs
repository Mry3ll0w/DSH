using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudManager : MonoBehaviour

{
    public TMP_Text time;
    public TMP_Text month;
    public TMP_Text year;
    float gameTime = 0.0f;

    void Update()
    {
        gameTime += Time.deltaTime;
        int hours = Mathf.FloorToInt(gameTime / 3600);  //horas
        int minutes = Mathf.FloorToInt(gameTime / 60);  //minutos
        int seconds = Mathf.FloorToInt(gameTime % 60);  //segundos
        time.text = "PM  " + string.Format("{0:0}:{1:00}:{2:00}",hours, minutes, seconds);
    }
}
