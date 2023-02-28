using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerarSuelo : MonoBehaviour
{
    private float dValX, dValY, dValZ;
    public GameObject goPrefabSuelo;
    public GameObject goPrefabTrampa;
    private Vector3 v3PosicionLimite;
    public System.Random rnd;
    private int r;

    // Start is called before the first frame update
    void Start()
    {
        dValX = dValY = dValZ = 0;
        v3PosicionLimite.x = 3;
        v3PosicionLimite.z = 12;
        rnd = new System.Random();
        SueloInicial();
    }

    // Update is called once per frame
    void Update()
    {
        GeneracionSuelo();
    }

    void SueloInicial()
    {
        for (int n = 0; n < 3; n++)
        {
            dValZ += 6.0f;
            GameObject elSuelo = Instantiate(
                goPrefabSuelo, new Vector3(dValX, dValY, dValZ),
                Quaternion.identity) as GameObject;

        }
        GameObject trampa = Instantiate(
            goPrefabTrampa, new Vector3(dValX, dValY, dValZ),
            Quaternion.identity) as GameObject;
        v3PosicionLimite.z = dValZ - 6;
        r = rnd.Next(1, 2);
    }

    void GeneracionSuelo()
    {
        switch (r)
        {
            case 1: GeneracionSueloRec();
                break;

            case 2: GeneracionSueloDer();
                break;
        }
    }
    void GeneracionSueloRec()
    {
        //Jugador
        GameObject goPlayer = GameObject.FindWithTag("Player");

        Vector3 v3PosJugador = goPlayer.transform.position; //obtener posici?n de la pelota


        if (v3PosJugador.z >= v3PosicionLimite.z && v3PosJugador.y >= 1)
        {
            for (int n = 0; n < 3; n++)
            {
                dValZ += 6.0f;//Si generamos vertical siempre no cambia
                GameObject elSuelo = Instantiate(
                    goPrefabSuelo, new Vector3(dValX, dValY, dValZ),
                    Quaternion.identity) as GameObject;

            }
            GameObject trampa = Instantiate(
            goPrefabTrampa, new Vector3(dValX - 1, 0.55f, dValZ - 1),
            Quaternion.identity) as GameObject;
            //Actualizamos el valor de la posicion limite
            v3PosicionLimite.z = dValZ - 6;
            r = rnd.Next(1, 3);
        }
    }

    void GeneracionSueloDer()
    {
        GameObject goPlayer = GameObject.FindWithTag("Player");
        Vector3 v3PosJugador = goPlayer.transform.position;
  

        if (v3PosJugador.z >= v3PosicionLimite.z && v3PosJugador.y >= 1)
        {
            for (int n = 0; n < 3; n++)
            {
                dValX += 6.0f;
                GameObject elSuelo = Instantiate(
                    goPrefabSuelo, new Vector3(dValX, dValY, dValZ),
                    Quaternion.identity) as GameObject;
            }
            GameObject trampa = Instantiate(
            goPrefabTrampa, new Vector3(dValX - 1, 0.55f, dValZ - 1),
            Quaternion.identity) as GameObject;
            r = rnd.Next(1, 3);
        }
    }
}