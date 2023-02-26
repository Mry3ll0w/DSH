using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Camera camara;
    public int iVelocidad;
    private float dValX, dValY,dValZ;
    private Vector3 offset;
    public GameObject goPrefabSuelo;
    private Vector3 v3PosicionLimite, v3PosicionGeneracion;

    // Start is called before the first frame update
    void Start()
    {
        dValX = dValY = dValZ = 0;
        offset = camara.transform.position;
        v3PosicionLimite.x = 0;
        v3PosicionLimite.z = 12;
        SueloInicial();
    }

    // Update is called once per frame
    void Update()
    {
        GeneracionSuelo();
    }

    void SueloInicial()
    {
        for(int n = 0; n < 3; n++)
        {
            dValZ += 6.0f;
            GameObject elSuelo = Instantiate(
                goPrefabSuelo, new Vector3(dValX, dValY, dValZ),
                Quaternion.identity) as GameObject;
            
        }
        v3PosicionLimite.z = dValZ - 3;
        
    }

    void GeneracionSuelo()
    {
        //Jugador
        GameObject goPlayer = GameObject.FindWithTag("Player");

        Vector3 v3PosJugador = goPlayer.transform.position;

        if (v3PosJugador.z >= v3PosicionLimite.z )
        {
            for (int n = 0; n < 3; n++)
            {
                dValZ += 6.0f;//Si generamos vertical siempren no cambia
                GameObject elSuelo = Instantiate(
                    goPrefabSuelo, new Vector3(dValX, dValY, dValZ),
                    Quaternion.identity) as GameObject;

            }

            //Actualizamos el valor de la posicion limite
            v3PosicionLimite.z = dValZ - 3;
        }

        
    }

}
