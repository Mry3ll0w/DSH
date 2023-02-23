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

    // Start is called before the first frame update
    void Start()
    {
        dValX = dValY = dValZ = 0;
        offset = camara.transform.position;
        SueloInicial();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
